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
    
    public partial class operacione
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public operacione()
        {
            this.rol_operacion = new HashSet<rol_operacion>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public Nullable<int> idModulo { get; set; }
    
        public virtual modulo modulo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rol_operacion> rol_operacion { get; set; }
    }
}
