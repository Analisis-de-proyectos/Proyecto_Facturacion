//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_Analisi
{
    using System;
    using System.Collections.Generic;
    
    public partial class detalleVenta
    {
        public int idDetalle { get; set; }
        public decimal numFactura { get; set; }
        public decimal idVenta { get; set; }
        public float subTotal { get; set; }
        public string idProducto { get; set; }
        public decimal descuento { get; set; }
        public int cantidad { get; set; }
    
        public virtual venta venta { get; set; }
        public virtual factura factura { get; set; }
        public virtual producto producto { get; set; }
    }
}
