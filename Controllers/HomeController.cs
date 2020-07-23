using LosGolosos.Models;
using System.Net;
using System.Net.Mail;
using System.Linq;
using System.Web.Mvc;
using System;
using System.Collections.Generic;

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
            ViewBag.ListaSexo = ComboSexo();
            return View();
        }
        [HttpPost]
        public ActionResult Login(UsuarioCLS oUsuarioCLS)
        {
            bool autenticado = false;
            
            using (BDGolososEntities bd = new BDGolososEntities())
            {
                autenticado = bd.Usuarios.Where(p => p.usuario.Equals(oUsuarioCLS.user) && p.clave.Equals(oUsuarioCLS.pass)).Count() == 1;

                if(autenticado)
                {
                    int idPersona = (int)bd.Usuarios.Where(p => p.usuario.Equals(oUsuarioCLS.user)).FirstOrDefault().idPersona;
                    if(bd.Empleados.Find(idPersona) != null)
                    {
                        oUsuarioCLS.idRol = (int)bd.Empleados.Find(idPersona).idCargo;
                    }
                    else
                    {
                        oUsuarioCLS.idRol = 3;
                    }
                }
                
            }

            if(autenticado)
            {
                Session["User"] = oUsuarioCLS;
                return RedirectToAction("Index");
            }


            ViewBag.ListaSexo = ComboSexo();
            return View(oUsuarioCLS);
        }

        public string Registrar(ClienteCLS oClienteCLS, string titulo)
        {
            string resp = "0";

            using (BDGolososEntities bd = new BDGolososEntities())
            {
                if (titulo.Equals("1"))
                {
                    Personas oPersona = new Personas();
                    oPersona.nombre = oClienteCLS.nombre;
                    oPersona.apellido = oClienteCLS.apellido;
                    oPersona.dir = oClienteCLS.dir;
                    oPersona.tel = oClienteCLS.tel;
                    oPersona.correo = oClienteCLS.correo;

                    bd.Personas.Add(oPersona);
                    bd.SaveChanges();

                    Clientes oCliente= new Clientes();
                    
                    int idPersona = bd.Personas.Where(p => p.correo.Equals(oClienteCLS.correo)).First().idPersona;
                    oCliente.idPersona = idPersona;

                    oCliente.registro = DateTime.Now;

                    bd.Clientes.Add(oCliente);
                    bd.SaveChanges();

                    Usuarios oUsuarios = new Usuarios();

                    oUsuarios.idPersona = idPersona;
                    oUsuarios.usuario = oClienteCLS.user;
                    oUsuarios.clave = oClienteCLS.pass;

                    bd.Usuarios.Add(oUsuarios);
                    resp = bd.SaveChanges().ToString();
                }
            }

            return resp;
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("User");
            return RedirectToAction("Index");
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

        public List<SelectListItem> ComboSexo()
        {
            List<SelectListItem> sourceList = new List<SelectListItem>();

            sourceList.Add(new SelectListItem { Text = "Masculino", Value = "M" });
            sourceList.Add(new SelectListItem { Text = "Femenino", Value = "F" });

            return sourceList;
        }

    }
}