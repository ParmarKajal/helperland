using Helperland.Models;
using Helperland.Models.Data;
using Helperland.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class HomeController : Controller
    {

        private readonly Helperland_DBContext _db;

        public HomeController(Helperland_DBContext db)
        {
            _db = db;
        }

        public IActionResult Contact()
        {
            ContactU contact = new ContactU();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Contact(ContactU contact)
        {
            _db.ContactUs.Add(contact);
            _db.SaveChanges();
            return RedirectToAction("Contact");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
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



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
