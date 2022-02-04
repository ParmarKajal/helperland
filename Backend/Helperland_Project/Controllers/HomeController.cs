using Helperland_Project.Models;
using Helperland_Project.Repository;
using Helperland_Project.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland_Project.Controllers
{
    public class HomeController : Controller
    {
       private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateAccountViewModel use)
        {
            using (Helperland_SchemaContext _tc = new Helperland_SchemaContext())
            {
                var detail = _tc.Users.Where(a => a.Email.Equals(use.email)
                && a.Password.Equals(use.Password)).FirstOrDefault();
                if (detail == null)
                {
                    ViewBag.Message("Invalid UserName And Password");
                    return View();
                }
                HttpContext.Session.SetString("Email", use.email);
                HttpContext.Session.SetString("Password", use.Password);
                if (detail != null)
                {
                    var check = use.RememberMe;
                    if (check == true)
                    {
                        string key = use.Password;
                        string value = use.email;
                        CookieOptions options = new CookieOptions
                        {
                            Expires = DateTime.Now.AddMinutes(5)
                        };
                        Response.Cookies.Append(key, value, options);

                    }
                    if (use.UserTypeId == 1)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    if(use.UserTypeId==2)
                    {
                        return RedirectToAction("ServiceProviderRegistration", "BecomeProvider");
                    }
                    
                }

            }
            return View();

        }
        public IActionResult LogeddIn(CreateAccountViewModel use)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                string key = use.Password;
                var CookieValue = Request.Cookies[key];


                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult LogeddOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        public IActionResult FAQ()
        {
            return View();
        }

        public IActionResult Price()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
