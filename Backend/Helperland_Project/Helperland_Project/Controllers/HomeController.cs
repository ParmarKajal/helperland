using Helperland_Project.Enum;
using Helperland_Project.Models;
using Helperland_Project.Models.Data;
using Helperland_Project.Repository;
using Helperland_Project.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Helperland_Project.Controllers
{
    public class HomeController : Controller
    {
       //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
           // _logger = logger;
        //}

        private readonly Helperland_SchemaContext _schema;

        public HomeController(Helperland_SchemaContext schema)
        {
            _schema = schema;
        }



        //Registration for customer
        public IActionResult Account()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Account(CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Password = Crypto.Hash(model.Password);
                model.ConfirmPassword = Crypto.Hash(model.ConfirmPassword);
                User user = new User
                {
                    FirstName = model.firstname,
                    LastName = model.lastname,
                    Email = model.email,
                    Mobile = model.mobile,
                    Password = model.Password,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    UserTypeId = (int)UserTypeIdEnum.Customer

                };

                _schema.Add(user);
                _schema.SaveChanges();
                return RedirectToAction();

            }

            return View();
        }




        //Registration for Service Provider
        public IActionResult ServiceProviderRegistration()
        {

            return View();
        }

        [HttpPost]
        public IActionResult ServiceProviderRegistration(CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Password = Crypto.Hash(model.Password);
                model.ConfirmPassword = Crypto.Hash(model.ConfirmPassword);

                User serviceprovider = new User
                {
                    FirstName = model.firstname,
                    LastName = model.lastname,
                    Email = model.email,
                    Mobile = model.mobile,
                    Password = model.Password,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    UserTypeId = (int)UserTypeIdEnum.ServiceProvider

                };
                _schema.Users.Add(serviceprovider);
                _schema.SaveChanges();
                return RedirectToAction();
            }

            return View();
        }


        //Login for all Users

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CreateAccountViewModel use)
        {
            using (Helperland_SchemaContext _tc = new Helperland_SchemaContext())
            {
                var detail = _tc.Users.Where(a => a.Email.Equals(use.email)).FirstOrDefault();

                if (detail == null)
                {
                    ViewBag.Message("Invalid UserName And Password");
                    return View();
                }
                HttpContext.Session.SetString("Email", use.email);
                HttpContext.Session.SetString("Password", use.Password);
                if (detail != null)
                {
                    if (string.Compare(Crypto.Hash(use.Password), detail.Password) == 0)
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
                            //HttpCookie cookie = new HttpCookie("CreateAccountViewModel");

                        }
                        if (use.UserTypeId == 1)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        if (use.UserTypeId == 2)
                        {
                            return RedirectToAction("ServiceProviderRegistration", "BecomeProvider");
                        }
                    }

                    else
                    {
                        ViewBag.message = "Invalid Password";
                    }
                }

            }
            return View();

        }


        //Loggedin
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

        //Loggedout
        public IActionResult LogeddOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }



        //ForgotPassword
        [HttpPost]
        public ActionResult ForgotPassword(string Email)
        {
            string ResetCode = Guid.NewGuid().ToString();

            var uriBuilder = new UriBuilder
            {
                Scheme = Request.Scheme,
                Host = Request.Host.Host,
                Port = Request.Host.Port ?? -1, //bydefault -1
                                                // Path = $"LoginPage/Home/ResetPassword/{ResetCode}"
                Path = $"LoginPage/Views/Home/ResetPassword/{ResetCode}"


            };
            var link = uriBuilder.Uri.AbsoluteUri;
            using (var context = new Helperland_SchemaContext())
            {
                var getUser = (from s in context.Users where s.Email == Email select s).FirstOrDefault();
                if (getUser != null)
                {
                    getUser.ResetPasswordCode = ResetCode;
                    _schema.SaveChanges();

                    var subject = "Password Reset Request";
                    var body = "Hi " + getUser.FirstName + ", <br/> You recently requested to reset your password for your account. Click the link below to reset it. " +

                         " <br/><br/><a href='" + link + "'>" + link + "</a> <br/><br/>" +
                         "If you did not request a password reset, please ignore this email or reply to let us know.<br/><br/> Thank you";

                    SendEmail(getUser.Email, body, subject);

                    ViewBag.Message = "Reset password link has been sent to your email id.";
                }
                else
                {
                    ViewBag.Message = "User doesn't exists.";
                    return RedirectToAction("ResetPassword");
                }
            }

            return RedirectToAction("ResetPassword");
        }




        //Send Email
        private void SendEmail(string emailAddress, string body, string subject)
        {
            using (MailMessage mm = new MailMessage("18comp.kajal.parmar@gmail.com", emailAddress))
            {
                mm.Subject = subject;
                mm.Body = body;

                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";




                smtp.UseDefaultCredentials = false;
                NetworkCredential NetworkCred = new System.Net.NetworkCredential("18comp.kajal.parmar@gmail.com", "1907kajal");
                smtp.Credentials = NetworkCred;
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(mm);

            }
        }





        //ResetPassword
        [HttpGet]
        public ActionResult ResetPassword(string id)
       {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            using (var context = new Helperland_SchemaContext())
            {
                var user = context.Users.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                if (user != null)
                {
                    ResetViewModel model = new ResetViewModel();
                    model.ResetCode = id;
                    return View(model);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetViewModel model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (var context = new Helperland_SchemaContext())
                {
                    var user = context.Users.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                    if (user != null)
                    {
                        user.Password = model.NewPassword;
                        user.ResetPasswordCode = "";
                        context.SaveChanges();
                        message = "New password updated successfully";
                    }
                }
            }
            else
            {
                message = "Something invalid";
            }
            ViewBag.Message = message;
            return View(model);
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
