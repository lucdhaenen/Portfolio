using WebsiteLD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace WebsiteLD.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Portfolio()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Succes = false;
            return View(new Contact());
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {            
            if (ModelState.IsValid)
            {
                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new System.Net.NetworkCredential("luc.dhaenen@gmail.com", "Monding10!");
                //smtp.EnableSsl = true;
                ////smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                
                
                ////MailMessage msg = new MailMessage(
                ////    "luc.dhaenen@gmail.com", "luc.dhaenen@gmail.com", "Mail van website", contact.BuildMessage()); 
                
                //MailMessage mail = new MailMessage();
                //mail.To.Add("luc.dhaenen@gmail.com");
                //mail.From = new MailAddress(contact.Email);
                //mail.Subject = contact.Onderwerp;
                //mail.Body = contact.Bericht;
                //mail.IsBodyHtml = true;

                MailMessage Message = new MailMessage();
                SmtpClient Smtp = new SmtpClient();
                System.Net.NetworkCredential SmtpUser = new System.Net.NetworkCredential();

                // Basis gegevens email
                Message.From = new MailAddress(contact.Email);
                Message.To.Add(new MailAddress("info@lumo.be"));
                Message.IsBodyHtml = false;

                // Gegevens onderwerp & Body
                Message.Subject = contact.Onderwerp;
                Message.Body = contact.Bericht;

                // SMTP Auth, een emailadres welke is aangemaakt in het control panel
                SmtpUser.UserName = "info@lumo.be";
                SmtpUser.Password = "Monding10!";

                // Bericht verzenden
                Smtp.UseDefaultCredentials = false;
                Smtp.Credentials = SmtpUser;
                Smtp.Host = "smtp.mijnhostingpartner.nl";
                
                //Smtp.EnableSsl = true;
                Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                
                try
                {
                    Smtp.Send(Message);               
                    //smtp.Send(mail);
                    //smtp.Send(msg);
                    ViewBag.succes = true;
                    return View("Gelukt");
                }
                catch (Exception ex)
                {
                    ViewBag.fout = ex;
                    ViewBag.succes = false;
                    return View("Gelukt");
                }                                 
            }
            else
            {
                return View(new Contact());
            }            
        }

        public ActionResult Gelukt()
        {
            return View("Gelukt");
        }
    }
}
