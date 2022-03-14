using Helperland_Project.Enum;
using Helperland_Project.Models.Data;
using Helperland_Project.Repository;
using Helperland_Project.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Helperland_Project.Controllers
{
    public class ServiceProviderController : Controller
    {
        private readonly Helperland_SchemaContext _schema;

        public ServiceProviderController(Helperland_SchemaContext schema)
        {
            _schema = schema;
        }


        // COMMON METHOD
        public IActionResult ServiceProviderLayout()
        {
            using (Helperland_SchemaContext db = new Helperland_SchemaContext())
            {
                List<User> user = new List<User>();
                List<ServiceRequestAddress> servicerequestaddress = new List<ServiceRequestAddress>();


                var ServiceProvider = db.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
                var ID = ServiceProvider.UserId;
                ViewBag.spname = ServiceProvider.FirstName;

                var request = db.ServiceRequests.Where(b => b.ServiceProviderId.Equals(ID)).ToList();
                foreach (var item in request)
                {
                    user.AddRange(db.Users.Where(b => b.UserId.Equals(item.UserId)).ToList());

                    servicerequestaddress.AddRange(db.ServiceRequestAddresses
                   .Where(b => b.ServiceRequestId.Equals(item.ServiceRequestId)).ToList());
                }



                List<ServiceRequest> servicerequest = db.ServiceRequests.Where(b => b.ServiceProviderId.Equals(ID)).ToList();




                var UpcomingRecord = from sr in servicerequest
                                     join sra in servicerequestaddress on sr.ServiceRequestId equals sra.ServiceRequestId into table1
                                     from sra in table1.ToList()
                                     join u in user on sr.UserId equals u.UserId into table2
                                     from u in table2.ToList()
                                     select new UpcomingViewModel
                                     {
                                         servicerequest = sr,
                                         servicerequestaddress = sra,
                                         user = u
                                     };
                return View(UpcomingRecord);
            }

        }


        //   UPCOMING SERVICES
        public IActionResult SPUpcomingService()
        {

            return View();
        }

        [HttpPost]
        public JsonResult UpcomingServiceDetail(int Id)
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

            // var Extra = details.ExtraHours;
            var NetAmount = details.SubTotal;

            var name = _schema.Users.Where(b => b.UserId.Equals(details.UserId)).FirstOrDefault();
            var Name = name.FirstName + " " + name.LastName;


            var AddressDetails = _schema.ServiceRequestAddresses.Where(b => b.ServiceRequestId.Equals(Id)).FirstOrDefault();
            var ServiceAddress = AddressDetails.AddressLine1 + AddressDetails.AddressLine2 + AddressDetails.City + AddressDetails.PostalCode;
            // var Phone = AddressDetails.Mobile;
            // var Email = AddressDetails.Email;
            // return View(_testContext.ServiceRequests.Where(b => b.ServiceRequestId.Equals(Id)).ToList());
            return Json(new
            {
                id = SrID,

                netamount = NetAmount,
                serviceaddress = ServiceAddress,


                servicedate = ServiceDate,
                servicetime = ServiceTime,
                duration = Duration,
                fname = Name
            });

        }


        public JsonResult CancleUpcomingService(int Id)
        {
            var details = _schema.ServiceRequests.Where(b => b.ServiceRequestId.Equals(Id)).FirstOrDefault();
            details.Status = (int)ServiceRequestStatus.cancelled;
            details.ModifiedDate = DateTime.Now;
            _schema.ServiceRequests.Update(details);

            _schema.SaveChanges();
            return Json(true);

        }



        public JsonResult CompleteUpcomingService(int Id)
        {
            var details = _schema.ServiceRequests.Where(b => b.ServiceRequestId.Equals(Id)).FirstOrDefault();
            DateTime dt = details.ServiceStartDate;              
            string datetime = dt.ToString();          
            string[] DateTim = datetime.Split(' ');  
            string Date = DateTim[0];                
            string Time = DateTim[1];
            string[] time = Time.Split(':');
            string clocktime = time[0] + ":" + time[1];

            var Extrahour = Convert.ToDouble(details.ExtraHours);
            var Extratime = details.ServiceHours + Extrahour;
            //  DateTime dts = Convert.ToDateTime(Extratime);
            DateTime end = Convert.ToDateTime(clocktime);
            DateTime watch = end.AddHours(Extratime);

            string Endtime = watch.ToString();

            string[] d = Endtime.Split(' ');
            string endt = d[1];
            // string[] endda = endt.Split(':');

            // string totaltime = endda[0] + ":" + endda[1] + ":" +;

            DateTime totaltime = Convert.ToDateTime(Date + " " + endt);





            DateTime Current_Date = DateTime.Now;


            if (totaltime < Current_Date)
            {

                details.Status = (int)ServiceRequestStatus.Completed;
                details.ModifiedDate = DateTime.Now;
                _schema.ServiceRequests.Update(details);
                _schema.SaveChanges();
                //ViewBag.Complete = "Your Service Is Complete. ";
                return Json(true);
            }
            else
            {
                // ViewBag.NotComplete = "Your End Time of the service  still not complete. ";
                return Json(false);
            }

        }




        //SP PROFILE

        public IActionResult SPProfile()
        {
            var Customer = _schema.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
            SPProfileViewModel mymodel = new SPProfileViewModel();
            var ID = Customer.UserId;
            ViewBag.ID = ID;

            mymodel.FirstName = Customer.FirstName;
            mymodel.LastName = Customer.LastName;
            mymodel.Email = Customer.Email;
            mymodel.Mobile = Customer.Mobile;
            mymodel.Gender = Customer.Gender;
            if (Customer.DateOfBirth != null)
            {

                string datetime = Customer.DateOfBirth.ToString();
                string[] DateTime = datetime.Split(' ');
                string Date = DateTime[0];


                string[] dob = Date.Split('-');
                mymodel.BirthYear = Int32.Parse(dob[2]);
                mymodel.BirthMonth = dob[1];
                mymodel.BirthDate = Int32.Parse(dob[0]);
            }


            var spaddress = _schema.UserAddresses.Where(b => b.UserId.Equals(ID)).FirstOrDefault();
            if (spaddress != null)
            {
                mymodel.AddressLine1 = spaddress.AddressLine1;
                mymodel.AddressLine2 = spaddress.AddressLine2;
                mymodel.City = spaddress.City;
                mymodel.PostalCode = spaddress.PostalCode;
            }


            return View(mymodel);

        }

        [HttpPost]
        public IActionResult ServiceProviderProfileDetail(SPProfileViewModel spmodel)
        {
            User use = _schema.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();

            use.FirstName = spmodel.FirstName;
            use.LastName = spmodel.LastName;
            use.Email = spmodel.Email;
            use.Mobile = spmodel.Mobile;
            use.Gender = spmodel.Gender;
            var BirthDate = spmodel.BirthDate + "-" + spmodel.BirthMonth + "-" + spmodel.BirthYear;
            DateTime birth = Convert.ToDateTime(BirthDate);
            use.DateOfBirth = birth;
            var ID = use.UserId;
            UserAddress spaddress = _schema.UserAddresses.Where(b => b.UserId.Equals(ID)).FirstOrDefault();
            if (spaddress == null)
            {
                UserAddress address = new UserAddress();
                address.UserId = ID;
                address.AddressLine1 = spmodel.AddressLine1;
                address.AddressLine2 = spmodel.AddressLine2;
                address.City = spmodel.City;
                address.PostalCode = spmodel.PostalCode;
                _schema.UserAddresses.Add(address);
                _schema.SaveChanges();
            }
            else
            {
                spaddress.AddressLine1 = spmodel.AddressLine1;
                spaddress.AddressLine2 = spmodel.AddressLine2;
                spaddress.City = spmodel.City;
                spaddress.PostalCode = spmodel.PostalCode;
                _schema.UserAddresses.Update(spaddress);
                _schema.SaveChanges();

            }
            _schema.Users.Update(use);
            _schema.SaveChanges();

            return View("ServiceProviderProfile");
        }

        [HttpPost]
        public IActionResult SPUpdatePassword(SPProfileViewModel sp)
        {
            User use = _schema.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
            var oldpwd = use.Password;
            var userid = use.UserId;

            if (string.Compare(Crypto.Hash(sp.OldPassword), oldpwd) == 0)
            {
                if (sp.Password == sp.ConfirmPassword)
                {
                    use.Password = sp.Password;
                    use.ModifiedDate = DateTime.Now;

                    _schema.Users.Update(use);
                    _schema.SaveChanges();
                    // return Ok(Json("true"));
                    TempData["Message"] = "Password Update Successfully";
                }
                else
                {
                    TempData["Message"] = "Does not match confirm password and New Password!";
                    // return Ok(Json("false"));
                }
            }
            else
            {
                // ViewBag.Pass = "Plz Enter Valid Old Password";
                TempData["Message"] = "Old Password is invalid";
                //return Ok(Json("false"));
            }

            return View("ServiceProviderProfile");
        }

        public IActionResult SPPassword()
        {
            return View();
        }


        //SP NEW SERVICE REQUEST

        [HttpGet]
        public IActionResult SPNewServiceRequest()
        {
            using (Helperland_SchemaContext db = new Helperland_SchemaContext())
            {
                List<User> user = new List<User>();
                List<ServiceRequestAddress> servicerequestaddress = new List<ServiceRequestAddress>();
               // List<ServiceRequest> servicerequest = new List<ServiceRequest>();
                var ServiceProvider = db.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
                // var ID = ServiceProvider.UserId;
                var zip = ServiceProvider.ZipCode;




                //var Fav = db.FavoriteAndBlockeds.Where(a => a.UserId.Equals(ServiceProvider.UserId) && a.IsBlocked == true).ToList();

                //foreach (var lg in Fav)
                //{

                //    servicerequest.AddRange(db.ServiceRequests.Where(a => a.ZipCode.Equals(zip) && a.UserId == lg.TargetUserId).ToList());


                //}

                var request = db.ServiceRequests.Where(b => b.ZipCode.Equals(zip)).ToList();
                foreach (var item in request)
                {
                    user.AddRange(db.Users.Where(b => b.UserId.Equals(item.UserId)).ToList());

                    servicerequestaddress.AddRange(db.ServiceRequestAddresses
                   .Where(b => b.ServiceRequestId.Equals(item.ServiceRequestId)).ToList());
                }

                List<ServiceRequest> servicerequest = db.ServiceRequests.Where(b => b.ZipCode.Equals(zip)).ToList();

                //var Upcome = from u in user
                //             join sr in user on u.UserId equals sr.UserId into table1
                //             from sr in table1.ToList()
                //             join sra in servicerequestaddress on u.U equals sra.ServiceRequestId into table2
                //             from sra in table2.ToList()
                //             select new UpcomingViewModel
                //             {
                //                 servicerequest = sr,
                //                 servicerequestaddress = sra,
                //                 user = u
                //             };


                var UpcomingRecord = from sr in servicerequest
                                     join sra in servicerequestaddress on sr.ServiceRequestId equals sra.ServiceRequestId into table1
                                     from sra in table1.ToList()
                                     join u in user on sr.UserId equals u.UserId into table2
                                     from u in table2.ToList().Distinct()
                                     select new UpcomingViewModel
                                     {
                                         servicerequest = sr,
                                         servicerequestaddress = sra,
                                         user = u
                                     };
                return View(UpcomingRecord);
            }

        }

        public JsonResult AcceptNewServiceRequest(int Id)
        {
            var accept = _schema.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();

            var spid = accept.UserId;
            var details = _schema.ServiceRequests.Where(b => b.ServiceRequestId.Equals(Id)).FirstOrDefault();

            details.ServiceProviderId = spid;
            details.Status = (int)ServiceRequestStatus.Accepted;
            details.ModifiedDate = DateTime.Now;
            details.SpacceptedDate = DateTime.Now;
            _schema.ServiceRequests.Update(details);

            _schema.SaveChanges();





            var emailmessage = _schema.Users.Where(b => b.ZipCode.Equals(details.ZipCode) && b.UserTypeId == 2 && b.UserId != spid).ToList();

            foreach (var EmailMessage in emailmessage)
            {
                var subject = "Regarding Servicr";
                var body = "Hi " + EmailMessage.FirstName + ", <br/> This" + spid + " Service is already booked by other service provider  Now No More Available For You " + "<br> Thank you";




                SendEmail(EmailMessage.Email, body, subject);
            }

            return Json(true);
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
                NetworkCredential NetworkCred = new System.Net.NetworkCredential("18comp.kajal.parmar@gmail.com", "1907kajal ");
                smtp.Credentials = NetworkCred;
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(mm);

            }
        }



        public IActionResult SPDetail()
        {
            return View();
        }


        // MyRating

        public IActionResult SPMyRating()
        {
            using (Helperland_SchemaContext db = new Helperland_SchemaContext())
            {
                List<User> user = new List<User>();

                var ServiceProvider = db.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
                var ID = ServiceProvider.UserId;

                var request = db.ServiceRequests.Where(b => b.ServiceProviderId.Equals(ID)).ToList();
                foreach (var item in request)
                {
                    user.AddRange(db.Users.Where(b => b.UserId.Equals(item.UserId)).ToList());


                }
                List<Rating> rating = db.Ratings.Where(b => b.RatingTo.Equals(ID)).ToList();

                List<ServiceRequest> servicerequest = db.ServiceRequests.Where(b => b.ServiceProviderId.Equals(ID)).ToList();




                var Upcom = from sr in servicerequest
                            join u in user on sr.UserId equals u.UserId into table1
                            from u in table1.ToList()
                            join r in rating on sr.ServiceRequestId equals r.ServiceRequestId into table2
                            from r in table2.ToList()
                            select new UpcomingViewModel
                            {
                                servicerequest = sr,
                                rating = r,
                                user = u
                            };
                return View(Upcom);
            }
        }



        // SP SERVICE HISTORY

        public IActionResult SPServiceHistory()
        {
            return View();
        }



        //BLOCK CUSTOMER

        public IActionResult SPBlockCustomer()
        {
            using (Helperland_SchemaContext db = new Helperland_SchemaContext())
            {
                List<User> user = new List<User>();
                var ServiceProvider = db.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
                var spid = ServiceProvider.UserId;

                var req = db.ServiceRequests.Where(b => b.ServiceProviderId.Equals(spid) && b.Status == 1).ToList();

                foreach (var item in req)
                {
                    user.AddRange(db.Users.Where(b => b.UserId.Equals(item.UserId)).ToList());
                }

                List<ServiceRequest> servicerequest = db.ServiceRequests.Where(b => b.ServiceProviderId.Equals(spid)).ToList();

                // List<FavoriteAndBlocked> favoriteandblocked = db.FavoriteAndBlockeds.ToList();
                // var fab = db.FavoriteAndBlockeds.Where(b => b.UserId.Equals(spid)).FirstOrDefault();
                //  var mb = fab.TargetUserId;
                // ViewBag.msg = mb;

                var CustomerRecord = from sr in servicerequest
                                     join u in user on sr.UserId equals u.UserId into table1
                                     from u in table1.ToList()
                                         //join f in favoriteandblocked on u.UserId equals f.TargetUserId into table2
                                         //from f in table2.ToList()

                                     select new UpcomingViewModel
                                     {
                                         servicerequest = sr,
                                         user = u,
                                         //favoriteandblocked = f
                                     };
                return View(CustomerRecord);

            }



            // IEnumerable<ServiceRequest> sr=_testContext.ServiceRequests.Include(x=>x.User).ThenInclude(x=>x.UserAddresses).

        }


        public IActionResult CheckBlock(int id)
        {
            var blocker = _schema.FavoriteAndBlockeds.Where(a => a.TargetUserId.Equals(id)).FirstOrDefault();
            if (blocker != null && blocker.IsBlocked == true)
            {
                return Json(true);
            }

            else
            {
                return Json(false);
            }
        }


        [HttpPost]
        public JsonResult BlockUser(int id)
        {

            var ServiceProvider = _schema.Users.Where(b => b.Email.Equals(HttpContext.Session.GetString("Email"))).FirstOrDefault();
            var spid = ServiceProvider.UserId;
            var condition = _schema.FavoriteAndBlockeds.Where(a => a.TargetUserId.Equals(id) & a.UserId.Equals(spid)).FirstOrDefault();
            FavoriteAndBlocked fb = new FavoriteAndBlocked();
            if (condition != null && condition.IsBlocked == true)
            {
                condition.IsBlocked = false;
                _schema.FavoriteAndBlockeds.Update(condition);
                _schema.SaveChanges();
                return Json(true);

            }

            else if (condition != null && condition.IsBlocked == false)
            {
                condition.IsBlocked = true;
                _schema.FavoriteAndBlockeds.Update(condition);
                _schema.SaveChanges();
                return Json(true);
            }

            else
            {
                fb.UserId = spid;
                fb.TargetUserId = id;
                fb.IsBlocked = true;

                _schema.FavoriteAndBlockeds.Add(fb);
                _schema.SaveChanges();
                return Json(true);
            }

        }
    }

}
