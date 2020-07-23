using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LosGolosos.Models
{
    public class ClienteCLS
    {
        [Display(Name = "ID")]
        public int idCliente { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Display(Name = "Dirección")]
        public string dir { get; set; }
        [Display(Name = "Teléfono")]
        public string tel { get; set; }
        [Display(Name = "Correo")]
        public string correo { get; set; }
        [Display(Name = "Registro")]
        public DateTime registro { get; set; }

        public string user { get; set; }
        public string pass { get; set; }
    }
}