using Rauf_Gaming_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace Rauf_Gaming_Web.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Faq()
        {
            return View();
        }
        public ActionResult Company()
        {
            return View();
        }
        public ActionResult Privacy()
        {
            return View();
        }
        public ActionResult TermsOfUse()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult SendEmail(Email email)
        {

            var fromAddress = new MailAddress(email.EmailAddress, email.Name);
            var toAddress = new MailAddress("manzoor.mcsd.net@gmail.com", "Rauf Store");
            string fromPassword = "Aximus2018@";
            string subject = email.Subject;
            string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("Aximus.forms@gmail.com", fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            return RedirectToAction("Faq");
        }
    }
}