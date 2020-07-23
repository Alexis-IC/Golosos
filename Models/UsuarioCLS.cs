using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace LosGolosos.Models
{
    public class UsuarioCLS
    {
        [Display(Name ="Usuario")]
        public string user { get; set; }
        [Display(Name = "Contraseña")]
        public string pass { get; set; }
        public int idRol { get; set; }
    }
}