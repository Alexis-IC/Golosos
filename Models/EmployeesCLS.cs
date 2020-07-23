using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.ComponentModel.DataAnnotations;

namespace LosGolosos.Models
{
    public class EmployeesCLS
    {
        [Display(Name ="ID")]
        public int idEmpleado { get; set; }
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
        [Display(Name = "Cargo")]
        public string cargo { get; set; }
        public int idCargo { get; set; }
        [Display(Name = "Género")]
        public string sexo { get; set; }
        [Display(Name = "DUI")]
        public string dui { get; set; }
        [Display(Name = "Estado")]
        public string estado { get; set; }
        public int idEstado { get; set; }

        public string user { get; set; }
        public string pass { get; set; }
    }
}