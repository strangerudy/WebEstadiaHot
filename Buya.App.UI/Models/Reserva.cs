//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Buya.App.UI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reserva
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reserva()
        {
            this.Hospedagem = new HashSet<Hospedagem>();
        }
    
        public int Id_Reserva { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Quarto { get; set; }
        public System.DateTime Data_Reserva { get; set; }
        public System.DateTime Data_Entrada { get; set; }
        public bool Estado { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hospedagem> Hospedagem { get; set; }
        public virtual Quarto Quarto { get; set; }
    }
}
