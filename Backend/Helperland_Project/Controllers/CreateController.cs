using Helperland_Project.Enum;
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
    public class CreateController : Controller
    {
        //private readonly Helperland_SchemaContext _schema;

        //public CreateController(Helperland_SchemaContext schema)
        //{
        //    _schema = schema;
        //}

        //[HttpGet]
        //public IActionResult Account()
        //{
           // User details = new User();
            //return View(details);
        //}
        //[HttpPost]
        //public IActionResult Account(User details)
        //{
            //if (ModelState.IsValid)
            //{
                //_schema.Users.Add(details);
                //_schema.SaveChanges();
                //return RedirectToAction("Account");
            //}

            //return View();

        //}


        
    //    public IActionResult Account()
    //    {
    //        return View();
    //    }

    //    [HttpPost]

    //    public IActionResult Account(CreateAccountViewModel model)
    //    {
    //        if(ModelState.IsValid)
    //        {
    //            User user = new User
    //            {
    //                FirstName = model.firstname,
    //                LastName = model.lastname,
    //                Email = model.email,
    //                Mobile = model.mobile,
    //                Password = model.Password,
    //                CreatedDate = DateTime.Now,
    //                ModifiedDate = DateTime.Now,
    //                UserTypeId=(int)UserTypeIdEnum.Customer
                    
    //            };

    //            _schema.Add(user);
    //            _schema.SaveChanges();
    //            return RedirectToAction();
               
    //        }

    //        return View();
    //    }

    //    [HttpPost]
    //    public IActionResult Login(LoginViewModel model)
    //    {
    //        return View();
    //    }
       
    }
}
