using Helperland_Project.Models.Data;
using Helperland_Project.Repository;
using Helperland_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland_Project.Controllers
{
    public class BecomeProviderController : Controller
    {
        private readonly Helperland_SchemaContext _db;
        public BecomeProviderController(Helperland_SchemaContext db)
        {
            _db = db;
        }
        public IActionResult ServiceProviderRegistration()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult ServiceProviderRegistration(CreateAccountViewModel model)
        {
            if(ModelState.IsValid)
            {
                User serviceprovider = new User
                {
                    FirstName = model.firstname,
                    LastName = model.lastname,
                    Email = model.email,
                    Mobile = model.mobile,
                    Password = model.Password,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,

                };
                _db.Users.Add(serviceprovider);
                _db.SaveChanges();
                return RedirectToAction();
            }

            return View();
        }
    }
}
