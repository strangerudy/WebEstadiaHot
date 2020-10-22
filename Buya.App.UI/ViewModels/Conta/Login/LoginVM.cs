using System.ComponentModel.DataAnnotations;

namespace Buya.App.UI.ViewModels.Conta.Login
{
    public class LoginVM
    {
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [StringLength(40, ErrorMessage = "O limite do {0} é de {1} caracteres")]
        //[RegularExpression(@"([\w.\-]+)@([\w\-]+)((\.(\w){2,3})+)", ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatória")]
        [StringLength(30, ErrorMessage = "O limite da {0} é de {1} caracteres")]
        public string Senha { get; set; }
        public bool PermanecerLogado { get; set; }
        public string ReturnURL { get; set; }
    }
}
