using LosGolosos.Models;
using System.Net;
using System.Net.Mail;
using System.Linq;
using System.Web.Mvc;
using System;

namespace LosGolosos.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(MailCLS oMailCLS)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(oMailCLS.desde);
                correo.To.Add("2541852018@mail.utec.edu.sv");
                correo.Subject = "Formulario de contácto - Los Golosos";
                correo.Body = oMailCLS.GenerarTicket();
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;


                //Configuración del servidor SMTP
                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("goloso.client@gmail.com", "?Ki_l-5>*");
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    client.Send(correo);
                }

            }
            catch(Exception ex)
            {
                return View(oMailCLS);
            }

            return RedirectToAction("Index");
        }

    }
}