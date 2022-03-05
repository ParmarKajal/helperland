using Helperland_Project.Models.Data;
using Helperland_Project.Repository;
using Helperland_Project.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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


        [HttpGet]
        public IActionResult Address()
        {
            var loggedinuser = _schema.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
            var userid = loggedinuser.UserId;
            System.Threading.Thread.Sleep(2000);
            return View(_schema.UserAddresses.Where(b=>b.UserId.Equals(userid)).ToList());
        }

        [HttpPost]
        public IActionResult YourDetail(int radio)
        {
            HttpContext.Session.SetInt32("AddressID", radio);
            return Ok(Json("true"));
        }



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
            };
            _schema.Add(add);
            _schema.SaveChanges();
            return Ok(Json("true"));
        }


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


        [HttpPost]

        public ActionResult CompleteBooking(BookNowViewModel booking)
        {
            var CustomerId = _schema.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
            int ID = CustomerId.UserId;

            var ZipValue = HttpContext.Session.GetString("ZipCode");
            var day = booking.ServiceDate.ToString("dd-MM-yyyy");
            var time = booking.ServiceTime.ToString("hh:mm:ss");
            var actual = day + " " + time;
            DateTime dt = DateTime.Parse(actual);
            booking.ServiceStartDate = dt;

            ServiceRequest service = new ServiceRequest
            {
                ZipCode = ZipValue,
                UserId = ID,
                ServiceStartDate = booking.ServiceStartDate,
                ServiceHourlyRate = booking.ServiceHourlyRate,
                ExtraHours = booking.ExtraHours,
                SubTotal = booking.SubTotal,
                ServiceHours = booking.ServiceHours,
                PaymentDone = true,
                Discount = booking.Discount,
                TotalCost = booking.TotalCost,
                Comments = booking.Comments,
                HasPets = booking.HasPets,
                //ServiceId=Guid.New Guid();
            };
            _schema.Add(service);
            _schema.SaveChanges();

            var AddressRadio = HttpContext.Session.GetInt32("AddressID");
            var AddressData = _schema.UserAddresses.Where(a => a.AddressId.Equals(AddressRadio)).FirstOrDefault();

            ServiceRequestAddress serviceaddress = new ServiceRequestAddress
            {
                AddressLine1 = AddressData.AddressLine1,
                AddressLine2 = AddressData.AddressLine2,
                City = AddressData.City,
                PostalCode = AddressData.PostalCode,
                Mobile = AddressData.Mobile,
                ServiceRequestId = service.ServiceRequestId,

            };
            ViewBag.Id = serviceaddress.ServiceRequestId;
            _schema.Add(serviceaddress);
            _schema.SaveChanges();
           

            var emailmessage = _schema.Users.Where(b => b.ZipCode.Equals(AddressData.PostalCode) && b.UserTypeId == 2).ToList();

            foreach (var EmailMessage in emailmessage)
            {
                var subject = "New Request Arrived";
                var body = "Greetings From Helperland, <br> " + EmailMessage.FirstName + ", <br/> Customer Wants to book a service in this area." + "<br> Thank you!";
                SendEmail(EmailMessage.Email, body, subject);
            }

            return Ok(Json("true"));
        }
    }
}
