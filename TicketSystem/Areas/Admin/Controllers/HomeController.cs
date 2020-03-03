using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.API.Domain.Domain;
using TicketSystem.API.Domain.ViewModels;
using TicketSystem.API.Service.Contract;

namespace TicketSystem.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Route("[area]/[action]")]
    [Authorize(Roles = Role.Admin)]
    public class HomeController : Controller
    {
        #region properties
        private readonly ILogger<HomeController> _logger;
        private readonly IUser _user;
        private readonly IClient _client;
        private readonly ITicket _ticket;
        private readonly IAdmin _admin;
        #endregion

        #region constructor
        public HomeController(ILogger<HomeController> logger, IUser user,IClient client,ITicket ticket,IAdmin admin)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _client = client ?? throw new ArgumentException(nameof(client));
            _ticket = ticket ?? throw new ArgumentNullException(nameof(ticket));
            _admin = admin ?? throw new ArgumentNullException(nameof(admin));
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            AdminVM adminView = new AdminVM();            
            bool _checkSession = CheckSession();
            if (_checkSession)return RedirectToAction(nameof(Logout));            
            try
            {
                adminView.clients = await _client.GetAllClients();
                adminView.getClientCount = await _admin.GetClientCount() ?? 0;
                adminView.getTicketCount = await _admin.GetTicketCount() ?? 0;
                adminView.getOpenTicketCount = await _admin.GetOpenTicketCount() ?? 0;
                adminView.getClosedTicketCount = await _admin.GetClosedTicketCount() ?? 0;
                adminView.getTicketInProgressCount = await _admin.GetTicketInProgressCount() ?? 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.InnerException?.InnerException?.Message}");
            }
            return View(adminView);
        }

        #region client
        [HttpGet]
        public IActionResult ClientOnBoard()
        {
            bool _checkSession = CheckSession();
            if (_checkSession) return RedirectToAction(nameof(Logout));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ClientOnBoard(ClientVM model)
        {
            bool _checkSession = CheckSession();
            if (_checkSession) return RedirectToAction(nameof(Logout));
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _client.RegisterClient(model);
                    if (result.responseCode == 200)
                    {
                        _logger.LogInformation($"Login Successful....");
                        //ViewData["msg"] = $"Client {model.name} created successfully";
                        ViewBag.msg = $"Client {model.name} created successfully";
                        return RedirectToAction(nameof(ClientOnBoard));
                    }
                    else
                    {
                        _logger.LogInformation($"Login Unsuccessful....");
                        //ViewData["msg"] = $"Could not create client {model.name}";
                        ViewBag.msg = $"Could not create client {model.name}";
                    }
                }
                else
                {
                    _logger.LogInformation($"Invalid model state....", model);
                    //ViewData["msg"] = $"Please fill out all fields";
                    ViewBag.msg = $"Please fill out all fields";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.InnerException?.InnerException?.Message}");
            }
            return RedirectToAction(nameof(ClientOnBoard));
        }

        public async Task<IActionResult> clientDetails(string clientEmail)
        {
            ClientProfile clientProfile = null;
            bool _checkSession = CheckSession();
            if (_checkSession) return RedirectToAction(nameof(Logout));
            try
            {
                clientProfile = await _client.ClientProfile(clientEmail);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.InnerException?.InnerException?.Message}");
            }
            return View(clientProfile);
        }

        #endregion

        #region Profile Client Users
        public async Task<IActionResult> ProfileClientUser()
        {
            ProfileClientUserVM clientUserVM = new ProfileClientUserVM();
            bool _checkSession = CheckSession();
            if (_checkSession) return RedirectToAction(nameof(Logout));
            try
            {
                var getClients = await _client.GetAllClients();
                var profile = new ProfileClientUser();
                clientUserVM.clients = getClients;
                clientUserVM.profileClientUser = profile;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.InnerException?.InnerException?.Message}");
            }
            return View(clientUserVM);
        }

        [HttpPost]
        public async Task<IActionResult> ProfileClientUser(ProfileClientUserVM model)
        {
            bool _checkSession = CheckSession();
            if (_checkSession) return RedirectToAction(nameof(Logout));
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _client.ProfileClientUser(model);
                    if (result!=null)
                    {
                        _logger.LogInformation($"profile client user successfully....");
                        TempData["msg"] = $"Client user created successfully";
                        return RedirectToAction(nameof(ProfileClientUser));
                    }
                    else
                    {
                        _logger.LogInformation($"creating profile client Unsuccessful....");
                        ViewBag.msg = $"Could not profile client user";
                    }
                }
                else
                {
                    _logger.LogInformation($"Invalid model state....", model);
                    //ViewData["msg"] = $"Please fill out all fields";
                    ViewBag.msg = $"Please fill out all fields";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.InnerException?.InnerException?.Message}");
            }
            return RedirectToAction(nameof(ProfileClientUser));
        }
        #endregion

        #region Ticket
        public async Task<IActionResult> RaisedTicket()
        {
            AdminTicketVM adminTicketVM = new AdminTicketVM();            
            bool _checkSession = CheckSession();
            if (_checkSession) return RedirectToAction(nameof(Logout));
            try
            {
                adminTicketVM.tickets = await _ticket.GetAllTicket();
                adminTicketVM.getClientCount = await _admin.GetClientCount() ?? 0;
                adminTicketVM.getTicketCount = await _admin.GetTicketCount() ?? 0;
                adminTicketVM.getOpenTicketCount = await _admin.GetOpenTicketCount() ?? 0;
                adminTicketVM.getClosedTicketCount = await _admin.GetClosedTicketCount() ?? 0;
                adminTicketVM.getTicketInProgressCount = await _admin.GetTicketInProgressCount() ?? 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.InnerException?.InnerException?.Message}");
            }
            return View(adminTicketVM);
        }

        public async Task<IActionResult> TicketDetails(string ticketId)
        {
            TicketDetail ticketDetail = null;
            bool _checkSession = CheckSession();
            if (_checkSession) return RedirectToAction(nameof(Logout));
            try
            {
                ticketDetail = await _ticket.GetTicket(ticketId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.InnerException?.InnerException?.Message}");
            }
            return View(ticketDetail);
        }
        #endregion

        #region check session
        public bool CheckSession()
        {
            var login = HttpContext.Session.GetString("Login");
            if (string.IsNullOrEmpty(login))return true;
            else return false;            
        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Logout", "Home", new { area = "" });
        }
        #endregion
    }
}