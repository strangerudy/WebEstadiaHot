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
    
    public partial class Funcionario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcionario()
        {
            this.Hospedagem = new HashSet<Hospedagem>();
            this.Pagamento = new HashSet<Pagamento>();
        }
    
        public int Id_Funcionario { get; set; }
        public string Nome_Funcionario { get; set; }
        public string N_BI { get; set; }
        public bool Sexo { get; set; }
        public Nullable<System.DateTime> Data_Nascimento { get; set; }
        public int AcessoId { get; set; }
    
        public virtual Acesso Acesso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hospedagem> Hospedagem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pagamento> Pagamento { get; set; }
    }
}
