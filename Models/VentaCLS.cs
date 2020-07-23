using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LosGolosos.Models
{
    public class VentaCLS
    {
        [Display(Name ="ID")]
        public int id { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Display(Name = "Teléfono")]
        public string tel { get; set; }
        [Display(Name = "Fecha de Pedido")]
        public DateTime fecha { get; set; }
        [Display(Name = "Estado")]
        public string estado { get; set; }
    }
}