using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using SchoolCare.Models;
using System.Net.Mail;
using System.Net;
using System.Web.Helpers;
using System.IO;

namespace SchoolCare.Controllers
{
    public class HomeController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
      
        public ActionResult Index()
        {
            return View();
        }
        [Route("About")]
        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }
        [Route("Contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Route("Contact")]
        [HttpPost]
        public ActionResult Contact(contact temp)
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "insert into contactDetails values(@name, @email, @mobile, @subject ,@message)";

            SqlCommand comm = new SqlCommand(query, con);
            comm.Parameters.AddWithValue("@name", temp.Name.Trim());
            comm.Parameters.AddWithValue("@email", temp.Email.ToLower().Trim());
            comm.Parameters.AddWithValue("@mobile", temp.Mobile.Trim());
            comm.Parameters.AddWithValue("@subject", temp.Subject.Trim());
            comm.Parameters.AddWithValue("@message", temp.Message.Trim());
            comm.ExecuteNonQuery();
            string emailid = temp.Email.Trim().ToLower();
            string senderemail = "ranjanashutosh493@gmail.com";
            string senderpassword = "sonhxijffwyglctj";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(senderemail);
            message.Subject = "Queriies or issues related to school care website";
            message.To.Add(new MailAddress(emailid));
            message.Body = "<html><body> We received you message and will fix all your problem soon. <br> Thanks for contacting us <br> Your message is very very importnat for us.</body><html>";
            message.IsBodyHtml = true;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(senderemail, senderpassword),
                EnableSsl = true,
            };
            smtpClient.Send(message);





            return View("Contact");
        }
        [Route("Features")]
        public ActionResult Features()
        {
            return View();
        }
        [Route("Login")]
        public ActionResult Login()
        {

            return View();
        }
        [Route("Login")]
        [HttpPost]
        public ActionResult Login(login temp)
        {
            //SqlConnection con = new SqlConnection("Data Source=LAPTOP-T2B5OAIV\\SQLEXPRESS;Initial Catalog=schoolcare;User ID=sa;Password=1234");
            SqlConnection con = new SqlConnection(cs);
            con.Open();
                string query = "select * from studentData where email = @email and password = @password";
                SqlCommand comm = new SqlCommand(query, con);
                comm.Parameters.AddWithValue("@email", temp.Email.ToLower().Trim());
                comm.Parameters.AddWithValue("@password", temp.Password);
                SqlDataReader reader1 = comm.ExecuteReader();
                if(reader1.Read())
                {
                TempData["email"] = temp.Email.ToLower().Trim();
            
                    return View("Dashboard");
                }
            
            return RedirectToAction("Error");
        }

        [Route("Profile1")]
        public ActionResult Profile1()
        {

            TempData.Keep("email");
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "select * from studentData where email = @email";
            SqlCommand comm = new SqlCommand(query, con);
            comm.Parameters.AddWithValue("@email", TempData["email"].ToString());
            SqlDataReader reader1 = comm.ExecuteReader();
            if (reader1.Read())
            {
                ViewBag.name = reader1["name"].ToString();
                ViewBag.class1 = reader1["class"].ToString();
                ViewBag.session = reader1["session"].ToString();
                ViewBag.roll = reader1["roll"].ToString();
                ViewBag.phone = reader1["phone"].ToString();
                ViewBag.email = reader1["email"].ToString();
                ViewBag.address = reader1["address"].ToString();
                ViewBag.bloodgroup = reader1["bloodgroup"].ToString();
                ViewBag.gender = reader1["gender"].ToString();
                ViewBag.dob = reader1["dob"].ToString();
                ViewBag.about = reader1["about"].ToString();
                ViewBag.img = reader1["photo"].ToString();
            }
            return View("Profile1");
        }


        [Route("Admitcard")]
        public ActionResult Admitcard()
        {
            TempData.Keep("email");
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "select * from studentData where email = @email";
            SqlCommand comm = new SqlCommand(query, con);
            comm.Parameters.AddWithValue("@email", TempData["email"].ToString());
            SqlDataReader reader1 = comm.ExecuteReader();
            if (reader1.Read())
            {
                ViewBag.name = reader1["name"].ToString();
                ViewBag.class1 = reader1["class"].ToString();
                ViewBag.session = reader1["session"].ToString();
                ViewBag.roll = reader1["roll"].ToString();
                ViewBag.phone = reader1["phone"].ToString();
                ViewBag.email = reader1["email"].ToString();
                ViewBag.address = reader1["address"].ToString();
                ViewBag.bloodgroup = reader1["bloodgroup"].ToString();
                ViewBag.gender = reader1["gender"].ToString();
                ViewBag.dob = reader1["dob"].ToString();
                ViewBag.about = reader1["about"].ToString();
                ViewBag.img = reader1["photo"].ToString();
            }

            return View("Admitcard");
        }

        [Route("Error")]
        public ActionResult Error()
        {
            return View();
        }
        [Route("Faculties")]
        public ActionResult Faculties()
        {
            return View();
        }
        [Route("App")]
        public ActionResult App()
        {
            return View();
        }
        [Route("Blog")]
        public ActionResult Blog()
        {
            return View();
        }
        [Route("ELearning")]
        public ActionResult ELearning()
        {
            return View();
        }
        [Route("Management")]
        public ActionResult Management()
        {
            return View();
        }
        [Route("Dashboard")]
        public ActionResult Dashboard()
        {
            return View();
        }
        [Route("Video")]
        public ActionResult Video()
        {
            return View();
        } 
        [Route("Lectures")]
        public ActionResult Lectures()
        {
            return View();
        }
        [Route("Otp")]
        public ActionResult Otp()
        {
            return View();
        }
        [Route("Otp")]
        [HttpPost]
        public ActionResult Otp(otp temp)
        {
            Random rnd = new Random();
            int number = rnd.Next(10000,100000);
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "select * from studentData where email = @email";
            SqlCommand comm = new SqlCommand(query, con);
            comm.Parameters.AddWithValue("@email", temp.Email.ToLower().Trim());
            SqlDataReader reader1 = comm.ExecuteReader();
            if (reader1.Read())
            {
                string emailid = temp.Email.Trim().ToLower();
                string senderemail = "ranjanashutosh493@gmail.com";
                string senderpassword = "sonhxijffwyglctj";

                MailMessage message = new MailMessage();
                message.From = new MailAddress(senderemail);
                message.Subject = "Otp for login to school care";
                message.To.Add(new MailAddress(emailid));
                message.Body = "<html><body> Your otp for school care log in is </body><html>" + number.ToString();
                message.IsBodyHtml = true;
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(senderemail, senderpassword),
                    EnableSsl = true,
                };
                smtpClient.Send(message);
                TempData["otp"] = number;
                TempData["email"] = temp.Email;
             
                return View("Otplogin");

            }

            return RedirectToAction("Error");
        }
        [Route("Otplogin")]
        public ActionResult Otplogin()
        {
            return View();
        } 
        [Route("Otplogin")]
        [HttpPost]
        public ActionResult Otplogin(otplogin temp)
        {
            if(temp.Number == TempData["otp"].ToString())
            {
                return View("Dashboard");
            }

            return RedirectToAction("Error");
        }
        [Route("WhatsappBot")]
        public ActionResult WhatsappBot()
        {
            return View();
        }
        [Route("WhatsappBot")]
        [HttpPost]
        public ActionResult WhatsappBot(whatsapp temp)
        {
            string emailid = temp.Email.Trim().ToLower();
            string senderemail = "ranjanashutosh493@gmail.com";
            string senderpassword = "sonhxijffwyglctj";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(senderemail);
            message.Subject = "Link to join whatsapp group";
            message.To.Add(new MailAddress(emailid));
            message.Body = "<html><body>Click on this link to joing our school care whatsapp group<a href="+@Url.Content("https://chat.whatsapp.com/GzZ9LtAsCFR6tjWq2ye7NV")+">Click here </a> </body></html>";
            message.IsBodyHtml = true;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(senderemail, senderpassword),
                EnableSsl = true,
            };
            smtpClient.Send(message);

            return View("WhatsappBot");
        }
        [Route("Tracking")]
        public ActionResult Tracking()
        {
            return View();
        }
        [Route("Signup")]
        public ActionResult Signup()
        {
            return View();
        }
        [Route("Signup")]
        [HttpPost]
        public ActionResult Signup(signup temp)
        {
            string path = Server.MapPath("~/Content/userImage");
            string fileName = Path.GetFileName(temp.Photo.FileName);
            string fullpath = Path.Combine(path, fileName);
            temp.Photo.SaveAs(fullpath);


            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "insert into studentData values(@name,@class,@session,@roll,@phone,@email,@address,@bloodgroup,@password,@gender,@dob,@photo,@about)";
            SqlCommand comm = new SqlCommand(query, con);
            comm.Parameters.AddWithValue("@name", temp.Name.Trim().ToUpper());
            comm.Parameters.AddWithValue("@class", temp.Class.Trim());
            comm.Parameters.AddWithValue("@session", temp.Session.Trim());
            comm.Parameters.AddWithValue("@roll", temp.Roll.Trim());
            comm.Parameters.AddWithValue("@phone", temp.Phone.Trim());
            comm.Parameters.AddWithValue("@email", temp.Email.Trim());
            comm.Parameters.AddWithValue("@address", temp.Address.Trim());
            comm.Parameters.AddWithValue("@bloodgroup", temp.Bloodgroup.Trim());
            comm.Parameters.AddWithValue("@password", temp.Password.Trim());
            comm.Parameters.AddWithValue("@gender", temp.Gender);
            comm.Parameters.AddWithValue("@dob", temp.Dob.Trim());
            comm.Parameters.AddWithValue("@photo", temp.Photo.FileName.ToString());
            comm.Parameters.AddWithValue("@about", temp.About.Trim());
            comm.ExecuteNonQuery();
          
            
         
                string emailid = temp.Email.Trim().ToLower();
                string senderemail = "ranjanashutosh493@gmail.com";
                string senderpassword = "sonhxijffwyglctj";

                MailMessage message = new MailMessage();
                message.From = new MailAddress(senderemail);
                message.Subject = "Registration in school care";
                message.To.Add(new MailAddress(emailid));
                message.Body = "<html><body> You are successfully registered for the school care .</body><html>";
                message.IsBodyHtml = true;
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(senderemail, senderpassword),
                    EnableSsl = true,
                };
                smtpClient.Send(message);
               

            
            return View("Login");
        }


        [Route("Logout")]
        public ActionResult Logout()
        {
            return View();
        }  
        [Route("Routine")]
        public ActionResult Routine()
        {
            return View();
        }
        [Route("Forget")]
        public ActionResult Forget()
        {
            return View();
        } 
        [Route("Forget")]
        [HttpPost]
        public ActionResult Forget(forget temp)
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "update studentData set password = @password where email = @email ";
            SqlCommand comm = new SqlCommand(query, con);
            comm.Parameters.AddWithValue("@email", temp.Email.Trim());
            comm.Parameters.AddWithValue("@password", temp.Password.Trim());
            comm.ExecuteNonQuery();
            string emailid = temp.Email.Trim().ToLower();
            string senderemail = "ranjanashutosh493@gmail.com";
            string senderpassword = "sonhxijffwyglctj";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(senderemail);
            message.Subject = "School care password updation";
            message.To.Add(new MailAddress(emailid));
            message.Body = "<html><body> You have successfully updated your password .</body><html>";
            message.IsBodyHtml = true;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(senderemail, senderpassword),
                EnableSsl = true,
            };
            smtpClient.Send(message);
            return View("Login");
        }
        [Route("Payment")]
        public ActionResult Payment()
        {
            return View();
        }


    }
}