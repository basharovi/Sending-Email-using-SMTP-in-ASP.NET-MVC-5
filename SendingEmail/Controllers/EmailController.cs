using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using SendingEmail.Models;
using System.Web.Mvc;

namespace SendingEmail.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmailViewModel emailViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var isSent = SendEmail(emailViewModel);
            if (!isSent)
            {
                ViewBag.Message = "Email Sending Failed!";
                return View();
            }

            ViewBag.Message = "Email has been sent Successfully!";

            return View();
        }

        private static bool SendEmail(EmailViewModel emailVm)
        {
            emailVm.EmailBody = @"<h3>Hello! </h3> <br /> <br />" +
                                emailVm.EmailBody + "<br /><br /><br />" +
                                "It's a Demo Email";

            emailVm.SenderEmailAddress = "itsdemo.247@gmail.com";
            emailVm.SenderPassword = ""; 
            emailVm.SmtpHostServer = "smtp.gmail.com";
            emailVm.SmtpPort = 587;

            try
            {
                var client = new SmtpClient(emailVm.SmtpHostServer, emailVm.SmtpPort)
                {
                    EnableSsl = true,
                    Timeout = 100000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(emailVm.SenderEmailAddress, emailVm.SenderPassword)
                };
                var mailMessage = new MailMessage
                {
                    IsBodyHtml = true,
                    BodyEncoding = Encoding.UTF8,
                    From = new MailAddress(emailVm.SenderEmailAddress)
                };
                mailMessage.To.Add(emailVm.ReceiverEmailAddress);
                mailMessage.Subject = emailVm.EmailSubject;
                mailMessage.Body = emailVm.EmailBody;
                client.Send(mailMessage);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}