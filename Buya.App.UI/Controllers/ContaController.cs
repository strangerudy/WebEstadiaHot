
using Buya.App.UI.Models;
using Buya.App.UI.ViewModels.Conta.Login;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using WebEstadiaHot.UsuarioActual;

namespace Buya.App.UI.Controllers
{
    public class ContaController : Controller
    {
        
        private readonly EstadiaHotBuyaEntities _usuarioRepository = new EstadiaHotBuyaEntities();

        //Injection
        //public ContaController(EstadiaHotEntities usuarioRepository)
        //{
        //    _usuarioRepository = usuarioRepository;
        //}

        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult IndexCliente()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string returnURL)
        {
            var model = new LoginVM() { ReturnURL = returnURL };
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            var usuario = _usuarioRepository.Acesso.Where(a => a.Email == model.Email).FirstOrDefault();
            //var achou = banco.Acesso.Where(a => a.Email == model.Email && a.Senha == model.Senha).FirstOrDefault();

            if (usuario == null)
            {
                ModelState.AddModelError("Email", "O e-mail não foi localizado");
            }
            else
            {
                if (usuario.Senha.Trim() != model.Senha.Trim())
                    ModelState.AddModelError("Senha", "Senha é inválida");
            }

            if (ModelState.IsValid)
            {
                DadosUsuarioActual.Id_Usuario = usuario.AcessoId;
                DadosUsuarioActual.NomeUsuario = usuario.Email;
                DadosUsuarioActual.Senha = usuario.Senha;
                DadosUsuarioActual.Cod_AcessoTipo = usuario.AcessoTipoId;
                DadosUsuarioActual.EstadoAutenticacao = 1;
                //Autenticação e criação de Cookie
                FormsAuthentication.SetAuthCookie(model.Email, model.PermanecerLogado);

                if (!string.IsNullOrEmpty(model.ReturnURL) && Url.IsLocalUrl(model.ReturnURL))
                {
                    return Redirect(model.ReturnURL);
                }
                if (DadosUsuarioActual.Cod_AcessoTipo == 1)
                {
                    return RedirectToAction("IndexAdmin", "Conta");
                }
                else if (DadosUsuarioActual.Cod_AcessoTipo == 3)
                {
                    return RedirectToAction("IndexCliente", "Conta");
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        protected override void Dispose(bool disposing)
        {

        }
    }
}
