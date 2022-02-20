using Helperland_Project.Models.Data;
using Helperland_Project.Repository;
using Helperland_Project.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland_Project.Controllers
{
    public class BookNowController : Controller
    {
        private readonly Helperland_SchemaContext _schema;

        public BookNowController(Helperland_SchemaContext schema)
        {
            _schema = schema;
        }

        [HttpGet]

        public IActionResult BookNow()
        {
            return View();
        }

        [HttpPost]

        public IActionResult ZipCodeValue(BookNowViewModel model)
        {
            if (HttpContext.Session.GetString("Email") != null)
            {
                var postal = _schema.Users.Where(b => b.ZipCode.Equals(model.ZipCode) && b.UserTypeId == 2).FirstOrDefault();
                if (postal != null)
                {
                    HttpContext.Session.SetString("ZipCode", model.ZipCode);
                    return Ok(Json("true"));
                }
                else
                {
                    return Ok(Json("false"));
                }
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        [HttpPost]

        public IActionResult Schedule(BookNowViewModel schedule)
        {
            // if(ModelState.IsValid)

            return Ok(Json("true"));

            //else
            //{
            //    return Ok(Json("false"));
            //}
        }



        [HttpPost]
        public  IActionResult YourDetail(BookNowViewModel address)
        {


         var value = HttpContext.Session.GetString("UserAddressList");
        address.Address= JsonConvert.DeserializeObject<IEnumerable<UserAddress>>(value);
        HttpContext.Session.SetString("YourDetailsViewModel", JsonConvert.SerializeObject(address));

        var ad= _schema.Add(add);
       _schema.SaveChanges();
           if(ad!=null)
            {
                return Ok(Json("true"));
            }

            else
            {
                return Ok(Json("false"));
           }
            return View();
        }


        [HttpGet]

        //public JsonResult GetUserAddresses(BookNowViewModel getaddress)
        //{
        //    var CustomerId = _schema.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
        //    int ID = CustomerId.UserId;

        //    getaddress.Address = _schema.UserAddresses.Where(c => c.UserId.Equals(ID)).ToList();
        //    var json = JsonConvert.SerializeObject(getaddress.Address);

        //    //return Json(json, JsonRequestBehavior.AllowGet);

        //}



        [HttpPost]

        public IActionResult AddNewAddress(BookNowViewModel address)

        {
            var user = _schema.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
            var userid = user.UserId;
            UserAddress add = new UserAddress
            {
                UserId = userid,
                AddressLine1 = address.addressline1,
                AddressLine2 = address.addressline2,
                City = address.city,
                State = address.state,
                PostalCode = address.postalcode,
                Mobile = address.mobile,
                //  Email = address.email,
            };


            _schema.Add(add);

            _schema.SaveChanges();
            return Ok(Json("true"));
        }

        [HttpPost]

        public ActionResult CompleteBooking(BookNowViewModel booking)
        {
            var CustomerId = _schema.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
            int ID = CustomerId.UserId;

            var ZipValue = HttpContext.Session.GetString("ZipCode");

            ServiceRequest service = new ServiceRequest
            {
                ZipCode = ZipValue,
                UserId = ID,
                ServiceStartDate = DateTime.Now,
                ServiceHourlyRate = booking.ServiceHourlyRate,
                ExtraHours = booking.ExtraHours,
                SubTotal = booking.SubTotal,
                ServiceHours = booking.ServiceHours,

                Discount = booking.Discount,
                TotalCost = booking.TotalCost,
                Comments = booking.Comments,
                HasPets = booking.HasPets,
            };
            _schema.Add(service);
            _schema.SaveChanges();
            return Ok(Json("true"));
        }
    }
}
