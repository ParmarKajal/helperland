using Helperland_Project.Models.Data;
using Helperland_Project.Repository;
using Helperland_Project.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland_Project.Controllers
{
    public class CustomerController : Controller
    {
        private readonly Helperland_SchemaContext _schema;

        public CustomerController(Helperland_SchemaContext schema)
        {
            _schema = schema;
        }

        [HttpGet]
        public IActionResult CustomPage()
        {
            var loggedinuser = _schema.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
            var userid = loggedinuser.UserId;
            ViewBag.FirstName = loggedinuser.FirstName;
            System.Threading.Thread.Sleep(2000);
            return View(_schema.ServiceRequests.Where(b => b.UserId.Equals(userid)).ToList());
        }


        [HttpGet]
        public IActionResult CustomerDashboard()
        {
           
           return View();
        }

        [HttpGet]
        public IActionResult ServiceHistory()
        {

            return View();
        }
       

        public IActionResult Profile()
        {
            var Customer = _schema.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
            ProfileViewModel mymodel = new ProfileViewModel();
            var ID = Customer.UserId;
            ViewBag.ID = ID;
            ViewBag.firstname = Customer.FirstName;

            mymodel.firstname = Customer.FirstName;
            mymodel.lastname = Customer.LastName;
            mymodel.email = Customer.Email;
            mymodel.Mobile = Customer.Mobile;
            return View(mymodel);
        }

        public IActionResult MyAddress()
        {
            var CustomerId = _schema.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
            int ID = CustomerId.UserId;

            var AddressID = _schema.UserAddresses.Where(b => b.UserId.Equals(ID)).FirstOrDefault();
            ViewBag.AddressID = AddressID.AddressId;

            System.Threading.Thread.Sleep(2000);
            return View(_schema.UserAddresses.Where(address => address.UserId.Equals(ID)).ToList());
        }


        [HttpPost]

        public ActionResult Profile(ProfileViewModel vm)
        {


            User profiledetails = new User();

            var data = (from userlist in _schema.Users
                        where userlist.Email == HttpContext.Session.GetString("Email")
                        select new
                        {
                            userlist.UserId,
                            userlist.FirstName,
                            userlist.LastName,
                            userlist.Email,
                            userlist.Mobile,
                            userlist.DateOfBirth,
                            userlist.Password

                        }).ToList();
            profiledetails.UserId = data[0].UserId;
            profiledetails.FirstName = vm.firstname;
            profiledetails.LastName = vm.lastname;
            profiledetails.Mobile = vm.Mobile;
            profiledetails.DateOfBirth = vm.DateOfBirth;
            profiledetails.Email = data[0].Email;
            profiledetails.UserTypeId = 1;
            profiledetails.IsRegisteredUser = true;
            profiledetails.WorksWithPets = true;
            profiledetails.CreatedDate = DateTime.Now;
            profiledetails.ModifiedDate = DateTime.Now;
            profiledetails.ModifiedBy = 1;
            profiledetails.IsApproved = true;
            profiledetails.IsActive = true;
            profiledetails.IsDeleted = true;
            profiledetails.Password = data[0].Password;


            _schema.Users.Update(profiledetails);
            _schema.SaveChanges();
            return Ok(Json("true"));
        }


        public JsonResult UpdateService(int Id, string ServiceDateTime)
        {
            DateTime Date = DateTime.Parse(ServiceDateTime);
            var details = _schema.ServiceRequests.Where(b => b.ServiceRequestId.Equals(Id)).FirstOrDefault();
            details.ServiceStartDate = Date;
            _schema.ServiceRequests.Update(details);
            _schema.SaveChanges();
            return Json(true);
        }

        public JsonResult CancleService(int Id)
        {
            var details = _schema.ServiceRequests.Where(b => b.ServiceRequestId.Equals(Id)).FirstOrDefault();
            var detail = _schema.ServiceRequestAddresses.Where(b => b.ServiceRequestId.Equals(Id)).FirstOrDefault();
            _schema.ServiceRequests.Remove(details);
            _schema.ServiceRequestAddresses.Remove(detail);
            _schema.SaveChanges();
            return Json(true);

        }


        [HttpPost]
        public JsonResult CustomerServiceDetail(int Id)
        {
            var details = _schema.ServiceRequests.Where(b => b.ServiceRequestId.Equals(Id)).FirstOrDefault();

            DateTime dt = details.ServiceStartDate;
            string datetime = dt.ToString();
            string[] DateTime = datetime.Split(' ');
            string Date = DateTime[0];
            string Time = DateTime[1];
            string[] time = Time.Split(':');
            string clocktime = time[0] + ":" + time[1];

            var ServiceDate = Date;
            var ServiceTime = clocktime;
            var Duration = details.ServiceHours;
            var SrID = details.ServiceRequestId;
            var Extra = details.ExtraHours;
            var NetAmount = details.SubTotal;


            var AddressDetails = _schema.ServiceRequestAddresses.Where(b => b.ServiceRequestId.Equals(Id)).FirstOrDefault();
            var ServiceAddress = AddressDetails.AddressLine1 + AddressDetails.AddressLine2 + AddressDetails.City + AddressDetails.PostalCode;
            var Phone = AddressDetails.Mobile;
            var Email = AddressDetails.Email;
            return Json(new
            {
                id = SrID,
                extra = Extra,
                netamount = NetAmount,
                serviceaddress = ServiceAddress,
                phone = Phone,
                email = Email,
                servicedate = ServiceDate,
                servicetime = ServiceTime,
                duration = Duration
            });

        }

        public JsonResult UpdateAddress(ProfileViewModel model)
        {

            var details = _schema.UserAddresses.Where(b => b.AddressId.Equals(model.AddressId)).FirstOrDefault();


            if (details == null)
            {
                var Customer = _schema.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();

                var ID = Customer.UserId;

                UserAddress use = new UserAddress();

                use.AddressLine1 = model.AddressLine1;
                use.AddressLine2 = model.AddressLine2;
                use.City = model.City;
                use.PostalCode = model.PostalCode;
                use.Mobile = model.Mobile;
                use.UserId = ID;
                _schema.Add(use);
                _schema.SaveChanges();
                return Json(true);
            }

            else
            {
                details.AddressId = model.AddressId;
                details.AddressLine1 = model.AddressLine1;
                details.AddressLine2 = model.AddressLine2;
                details.City = model.City;
                details.PostalCode = model.PostalCode;
                details.Mobile = model.Mobile;

                _schema.UserAddresses.Update(details);
                _schema.SaveChanges();
                return Json(true);
            }

        }

        public JsonResult RemoveAddress(int Id)
        {
            var details = _schema.UserAddresses.Where(b => b.AddressId.Equals(Id)).FirstOrDefault();

            _schema.UserAddresses.Remove(details);
            _schema.SaveChanges();
            return Json(true);

        }

        [HttpPost]
        public IActionResult UpdatePassword(ProfileViewModel sp)
        {
            User use = _schema.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
            var oldpwd = use.Password;
            var userid = use.UserId;

            if (string.Compare(Crypto.Hash(sp.OldPassword), oldpwd) == 0)
            {
                if (sp.Password == sp.ConfirmPassword)
                {
                    sp.Password = Crypto.Hash(sp.Password);
                    use.Password = sp.Password;
                    use.ModifiedDate = DateTime.Now;
                    //use.CreatedDate = DateTime.Now;
                    _schema.Users.Update(use);
                    _schema.SaveChanges();
                    TempData["Message"] = "Password Update Successfully";
                }
                else
                {
                    TempData["Message"] = "Does not match confirm password and New Password!";
                   
                }
            }
            else
            {
               
                TempData["Message"] = "Old Password is invalid";
               
            }

            return View("Profile");
        }


        public JsonResult Rating(int id, int OnTimeArrival, int Friendly, int QualityOfService, decimal Ratings, string Comments)
        {
            var sr = _schema.ServiceRequests.Where(a => a.ServiceRequestId.Equals(id)).FirstOrDefault();
            Rating ratingtable = _schema.Ratings.Where(a => a.ServiceRequestId.Equals(id)).FirstOrDefault();
            if (ratingtable != null)
            {

                ratingtable.OnTimeArrival = OnTimeArrival;
                ratingtable.Friendly = Friendly;
                ratingtable.QualityOfService = QualityOfService;
                ratingtable.RatingDate = DateTime.Now;
                ratingtable.Ratings = Ratings;
                _schema.Ratings.Update(ratingtable);
                _schema.SaveChanges();


            }

            else
            {

                Rating rate = new Rating();
                rate.ServiceRequestId = sr.ServiceRequestId;
                rate.RatingFrom = sr.UserId;
                rate.RatingTo = Convert.ToInt32(sr.ServiceProviderId);
                rate.Ratings = Ratings;
                rate.OnTimeArrival = OnTimeArrival;
                rate.Friendly = Friendly;
                rate.QualityOfService = QualityOfService;
                rate.RatingDate = DateTime.Now;
                rate.Comments = Comments;

                _schema.Ratings.Add(rate);
                _schema.SaveChanges();
            }
            return Json(true);
        }

    }
}
