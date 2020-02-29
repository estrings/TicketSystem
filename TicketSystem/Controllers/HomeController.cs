using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TicketSystem.API.Common.Helpers;
using TicketSystem.API.Domain.ViewModels;
using TicketSystem.API.Service.Contract;

namespace TicketSystem.Controllers
{
    public class HomeController : Controller
    {
        #region properties
        private readonly ILogger<HomeController> _logger;
        private readonly IUser _user;
        private readonly IBase64Helper _base64Helper;
        private readonly IClient _client;
        #endregion

        #region constructor
        public HomeController(ILogger<HomeController> logger,IUser user,IBase64Helper base64Helper, IClient client)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _base64Helper = base64Helper ?? throw new ArgumentNullException(nameof(base64Helper));
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        #endregion
        public IActionResult Index() => View();

        #region Login
        public IActionResult Login()
        {            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Authenticate model, string returnURL=null)
        {
            try
            {
                if (ModelState.IsValid)
                {                   
                    var result = await _user.AuthenticateUser(model);
                    if (result.responseCode == 200)
                    {
                        var clientUserDetails = await _user.GetUserProfile(result.responseObject.userObject.userName);
                        if (clientUserDetails.responseCode==200)
                        {
                            _logger.LogInformation($"Login Successful....");
                            ViewData["msg"] = $"Welcome {model.username.ToUpper()}";
                            string login = result.responseObject.authToken;
                            string username = result.responseObject.userObject.firstName + " " + result.responseObject.userObject.lastName;
                            string _cID = clientUserDetails.responseObject.clientId ?? null;
                            var claims = new List<Claim>
                        {
                          new Claim(ClaimTypes.Authentication,result.responseObject.authToken),
                           new Claim(ClaimTypes.Role,result.responseObject.userObject.accessType)
                        };
                            var authentication = new ClaimsIdentity(claims, "authToken");
                            ClaimsPrincipal principal = new ClaimsPrincipal(authentication);
                            HttpContext.Session.SetString("Login", login);
                            HttpContext.Session.SetString("Username", username);
                            if(_cID!=null) HttpContext.Session.SetString("ClientID", _cID);
                            return RedirectToAction(nameof(checkAccessType), new { accessType = result.responseObject.userObject.accessType});
                        }
                    }
                    else
                    {
                        _logger.LogInformation($"Login Unsuccessful....");
                        TempData["msg"] = $"Authentication failed for {model.username}";
                    }
                }
                else
                {
                    _logger.LogInformation($"Invalid model state....",model);
                    ViewData["msg"] = $"Please fill out all fields";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.InnerException?.InnerException?.Message}");
            }
            return RedirectToAction(nameof(Login));
        }
        #endregion


        #region Registration
        public IActionResult Registration()
        {
            ViewData["Title"] = "Registration";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(Registration model, string returnURL=null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //string accessType = checkAccessType(model.accessType);
                    //model.accessType = accessType;
                    //var result = await _user.RegisterUser(model);
                    //if (result.responseCode == 200)
                    //{
                    //    ViewData["msg"] = $"{model.firstname + " " + model.lastname} created successfully";
                    //}
                    //else
                    //{
                    //    ViewData["msg"] = $"Could not create the {model.firstname+" "+model.lastname}";
                    //}
                }
                else
                {
                    ViewData["msg"] = $"Please fill out all fields";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.InnerException?.InnerException?.Message}");
            }
            return RedirectToAction(nameof(Registration));
        }
        #endregion

        #region access Type
        public IActionResult checkAccessType(string accessType)
        {
            switch (accessType)
            {
                case "Administrator": 
                    return RedirectToAction(nameof(Index), new { area = "Admin" });
                case "Support": 
                    return RedirectToAction(nameof(Index), new { area = "Support" });
                case "Client":
                    return RedirectToAction(nameof(Index), new { area = "Client" });
                default:
                    return RedirectToAction(nameof(Login));
            }
        }
        #endregion


        #region Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }
        #endregion

    }
}
