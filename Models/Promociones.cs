//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LosGolosos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Promociones
    {
        public int idPromocion { get; set; }
        public Nullable<int> idProducto { get; set; }
        public string nombre { get; set; }
        public Nullable<decimal> descuento { get; set; }
        public Nullable<bool> activa { get; set; }
        public Nullable<System.DateTime> inicio { get; set; }
        public Nullable<System.DateTime> fin { get; set; }
    
        public virtual Productos Productos { get; set; }
    }
}