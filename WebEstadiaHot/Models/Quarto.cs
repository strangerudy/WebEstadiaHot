//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebEstadiaHot.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quarto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quarto()
        {
            this.Reserva = new HashSet<Reserva>();
        }
    
        public int Id_Quarto { get; set; }
        public string Descricao { get; set; }
        public int Id_Quarto_Tipo { get; set; }
        public int Id_Estado_Quarto { get; set; }
    
        public virtual Estado_Quarto Estado_Quarto { get; set; }
        public virtual Quarto_Tipo Quarto_Tipo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
