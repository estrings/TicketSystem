using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TicketSystem.API.Common.Helpers;
using TicketSystem.API.Domain.Domain;
using TicketSystem.API.Domain.ViewModels;
using TicketSystem.API.Service.Contract;

namespace TicketSystem.Areas.Client.Controllers
{
    [Area(nameof(Client))]
    [Route("[area]/[action]")]
    [Authorize(Roles = Role.Client)]
    public class HomeController : Controller
    {
        #region properties
        private readonly ILogger<HomeController> _logger;
        private readonly IClient _client;
        private readonly ITicket _ticket;
        private readonly IBase64Helper _base64Helper;
        #endregion

        #region constructor
        public HomeController(ILogger<HomeController> logger,IClient client, ITicket ticket,IBase64Helper base64Helper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _ticket = ticket ?? throw new ArgumentNullException(nameof(ticket));
            _base64Helper = base64Helper ?? throw new ArgumentNullException(nameof(base64Helper));
        }
        #endregion
        //public async Task<IActionResult> Index()
        //{
        //    Tickets allTickets = null;
        //    bool _checkSession = CheckSession();
        //    if (_checkSession) return RedirectToAction(nameof(Logout));
        //    try
        //    {
        //        allTickets = await _ticket.GetAllTicket();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"{ex?.InnerException?.InnerException?.Message}");
        //    }
        //    return View(allTickets);
        //}

        public async Task<IActionResult> Index()
        {
            Tickets allClientTickets = null;
            bool _checkSession = CheckSession();
            if (_checkSession) return RedirectToAction(nameof(Logout));
            try
            {
                var cid = HttpContext.Session.GetString("ClientID");
                allClientTickets = await _ticket.GetTicketByClientId(cid);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.InnerException?.InnerException?.Message}");
            }
            return View(allClientTickets);
        }

        #region ticket

        [HttpGet]
        public async Task<IActionResult> RaiseTicket()
        {
            TicketVM ticketVM = new TicketVM();
            bool _checkSession = CheckSession();
            if (_checkSession) return RedirectToAction(nameof(Logout));
            try
            {
                var getClients = await _client.GetAllClients();
                ticketVM.clients = getClients;

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.InnerException?.InnerException?.Message}");
            }
            return View(ticketVM);
        }

        public async Task<IActionResult> RaiseTicket(TicketVM model)
        {
            bool _checkSession = CheckSession();
            if (_checkSession) return RedirectToAction(nameof(Logout));
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _ticket.RaiseTicket(model);
                    if (result != null)
                    {
                        _logger.LogInformation($"ticket raised successfully....");
                        TempData["msg"] = $"Ticket created successfully";
                    }
                    else
                    {
                        _logger.LogInformation($"could not raise ticket....");
                    }
                }
                else
                {
                    _logger.LogInformation($"Invalid model state....", model.clients);
                    ViewBag.msg = $"Please fill out all fields";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.InnerException?.InnerException?.Message}");
            }
            return RedirectToAction(nameof(Index));
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
            if (string.IsNullOrEmpty(login)) return true;
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