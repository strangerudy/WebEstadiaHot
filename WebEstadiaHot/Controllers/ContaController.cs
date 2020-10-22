using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebEstadiaHot.Models;
using WebEstadiaHot.UsuarioActual;
using WebEstadiaHot.ViewModels.Conta.Login;

namespace WebEstadiaHot.Controllers
{
    public class ContaController : Controller
    {
        EstadiaHotEntities banco = new EstadiaHotEntities();

        AcessoTipo acessoTipo = new AcessoTipo();

        // GET: Conta
        public ActionResult Index()
        {
            return View(ObterAcessoClassificadasPorNome());
        }

        public IQueryable<AcessoTipo> ObterAcessoTipoClassificadasPorNome()
        {
            return banco.AcessoTipo.OrderBy(b => b.AcessoTipo1);
        }
        public IQueryable<Acesso> ObterAcessoClassificadasPorNome()
        {
            return banco.Acesso.OrderBy(b => b.AcessoId);
        }

        private void PopularViewBag(Acesso acesso = null)
        {
            /*
            	passar os tipos de acesso para	a ViewBag, que serão carregados no DropDownList da View(visão).	
            */
            if (acesso == null)
            {
                //para o create
                ViewBag.AcessoTipoId = new SelectList(ObterAcessoTipoClassificadasPorNome(), "AcessoTipoId", "AcessoTipo1");
            }
            else
            {
                //para o edit
                ViewBag.AcessoTipoId = new SelectList(ObterAcessoTipoClassificadasPorNome(), "AcessoTipoId", "AcessoTipo1", acessoTipo.AcessoTipoId);
            }
        }

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
            using (banco)
            {
                var achou = banco.Acesso.Where(a => a.Email == model.Email && a.Senha == model.Senha).FirstOrDefault();

                //DadosUsuarioActual dadosActual = new DadosUsuarioActual();

                if (achou != null)
                {
                    if (achou.AcessoTipoId == 1)
                    {
                        TempData["mensagem"] = "Bem-vindo ao sistema!";

                        DadosUsuarioActual.Id_Usuario = achou.AcessoId;
                        DadosUsuarioActual.NomeUsuario = achou.Email;
                        DadosUsuarioActual.Senha = achou.Senha;
                        DadosUsuarioActual.Cod_AcessoTipo = achou.AcessoTipoId;
                        DadosUsuarioActual.EstadoAutenticacao = 1;

                        FormsAuthentication.SetAuthCookie(model.Email, model.PermanecerLogado);

                        if (!string.IsNullOrEmpty(model.ReturnURL) && Url.IsLocalUrl(model.ReturnURL))
                        {
                            return Redirect(model.ReturnURL);
                        }

                        return RedirectToAction("IndexAdmin", "Conta");
                    }
                    if (achou.AcessoTipoId == 3)
                    {
                        TempData["mensagem"] = "Bem-vindo ao sistema!";

                        DadosUsuarioActual.Id_Usuario = achou.AcessoId;
                        DadosUsuarioActual.NomeUsuario = achou.Email;
                        DadosUsuarioActual.Senha = achou.Senha;
                        DadosUsuarioActual.Cod_AcessoTipo = achou.AcessoTipoId;
                        DadosUsuarioActual.EstadoAutenticacao = 1;

                        FormsAuthentication.SetAuthCookie(model.Email, model.PermanecerLogado);
                                               

                        return RedirectToAction("IndexCliente", "Acessos");
                    }

                    return View();
                }
                else
                {
                    
                    TempData["mensagem"] = "Login Invalido";
                    return View(model);
                }
                                
            }            
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: Acessos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Acessos/Create
        public ActionResult CreateAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdmin(Acesso acesso)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    banco.Acesso.Add(acesso);
                }
                banco.SaveChanges();
                return View();
                //return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Acessos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acessos/Create
        [HttpPost]
        public ActionResult Create(Acesso acesso) //Usuário anonimo cadastra cliente
        {
            try
            {
                if (acesso.AcessoTipoId <= 0)
                {
                    acesso.AcessoTipoId = 3;
                }

                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    banco.Acesso.Add(acesso);
                }
                banco.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}