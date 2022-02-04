using Helperland_Project.Models.Data;
using Helperland_Project.Repository;
using Helperland_Project.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland_Project.Controllers
{
    public class ContactController : Controller
    {
        private readonly Helperland_SchemaContext _db;
        private readonly IHostingEnvironment hostingEnvironment;

        public ContactController(Helperland_SchemaContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
           this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ContactUs(ContactUsViewModel model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.uploadFileName != null)
                {
                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "filestore");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.uploadFileName.FileName;
                    string filepath = Path.Combine(uploadFolder, uniqueFileName);
                    model.uploadFileName.CopyTo(new FileStream(filepath, FileMode.Create));
                }
                ContactU contactus = new ContactU
                {
                    Name = model.firstname + "  " + model.lastname,
                    Email = model.email,
                    PhoneNumber = model.mobile,
                    Subject = model.subject,
                    Message = model.message,
                    UploadFileName = uniqueFileName

                };

                _db.Add(contactus);
                _db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}
