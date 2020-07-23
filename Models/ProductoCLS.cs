using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Configuration;

namespace LosGolosos.Models
{
    public class ProductoCLS
    {
        public int idProducto { get; set; }
        public int idCategoria { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Imagen")]
        public string imagen { get; set; }
        public HttpPostedFileBase archivo { get; set; }
        [Display(Name = "Detalle")]
        public string detalle { get; set; }
        [Display(Name = "Existencias")]
        public int stock { get; set; }
        [Display(Name = "Precio Unitario")]
        public decimal precio { get; set; }
        [Display(Name = "Tipo")]
        public string categoria { get; set; }

        public int pedidos { get; set; }
    }
}