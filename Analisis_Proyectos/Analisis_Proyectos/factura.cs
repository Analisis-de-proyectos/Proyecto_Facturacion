//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Analisis_Proyectos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public factura()
        {
            this.detalleVentas = new HashSet<detalleVenta>();
        }
        [Display(Name = "Numero de factura")]
        public decimal numFactura { get; set; }

        public System.DateTime fecha { get; set; }

        public float IVA { get; set; }
        [Display(Name = "Total")]
        public float total { get; set; }
        [Display(Name = "Referencia de pago")]
        public int numPago { get; set; }
        [Display(Name = "Descuento")]
        public Nullable<decimal> descuento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleVenta> detalleVentas { get; set; }
        [Display(Name = "Modo de pago")]
        public virtual modoPago modoPago { get; set; }
    }
}
