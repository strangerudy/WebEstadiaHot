using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buya.App.UI.ViewModels.Clientes
{
    public class ClienteVM
    {
        [Key]
        public int Id { get; set; }
        public string Nome_Cliente { get; set; }
        public string Num_BI { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Sexo { get; set; }
        public string Num_Telefone { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
