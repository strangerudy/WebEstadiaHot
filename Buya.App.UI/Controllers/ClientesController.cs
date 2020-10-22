using Buya.App.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Buya.App.UI.ViewModels.Clientes;
using Buya.App.UI.ViewModels.Clientes.Maps;

namespace Buya.App.UI.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private EstadiaHotBuyaEntities db = new EstadiaHotBuyaEntities();

        // GET: Clientes
        public ActionResult Index()
        {
            var cliente = db.Cliente.Include(a => a.Acesso.AcessoTipo);
            return View(cliente.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }


        [HttpGet]
        public ActionResult AddEdit(int? id)
        {
            var cliente = new Cliente();
            if (id != null)
            {
                // _produtoRepository.Get((int)id).ToProdutoAddEditVM();

                cliente = db.Cliente.Find((int)id);
            }
            return View(cliente);
        }

        [HttpPost]
        public ActionResult AddEdit(Cliente cliente) //Guardar na Tabela
        {
            //var cliente = clienteVM.ToCliente();

            //Falta fazer a validação
            if (ModelState.IsValid)
            {
                if (cliente.Id_Cliente == 0) //Para salvar novo produto
                {
                    db.SP_ClienteAddEdit(0, cliente.Nome_Cliente, cliente.Sexo, cliente.N_BI, cliente.Data_Nascimento, cliente.Telefone,
                                 cliente.Acesso.Email, "#hbuya2019!");
                    db.SaveChanges();
                }
                else //Para actualizar produto existente
                {
                    db.SP_ClienteAddEdit(cliente.Id_Cliente, cliente.Nome_Cliente, cliente.Sexo, cliente.N_BI, cliente.Data_Nascimento, cliente.Telefone,
                                 cliente.Acesso.Email, cliente.Acesso.Senha);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(cliente);
        }




        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.AcessoTipoId = new SelectList(db.AcessoTipo, "AcessoTipoId", "AcessoTipo1");
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            //Definir Senha
            //Cliente Senha Padrão -> #hbuya2019!
            
            if (ModelState.IsValid)
            {
                db.SP_ClienteAddEdit(0, cliente.Nome_Cliente, cliente.Sexo, cliente.N_BI, cliente.Data_Nascimento, cliente.Telefone,
                                 cliente.Acesso.Email, "#hbuya2019!");
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcessoTipoId = new SelectList(db.AcessoTipo, "AcessoTipoId", "AcessoTipo1", cliente.Acesso.AcessoTipoId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AcessoId,Email,Senha,AcessoTipoId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcessoTipoId = new SelectList(db.AcessoTipo, "AcessoTipoId", "AcessoTipo1", cliente.Acesso.AcessoTipoId);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        //--------------CONSUMO DA API---------------

        //// GET: Consultar API
        //[HttpGet]
        //public ActionResult ConsultaClienteAPI()
        //{

        //    return View();
        //}
        //[HttpPost]
        public ActionResult ConsultaClienteAPI(int parametroBD=1)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/api/cliente/"+parametroBD);
                //HTTP GET
                var responseTask = client.GetAsync("cliente");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ClienteVM[]>();
                    readTask.Wait();

                    var clientes = readTask.Result;

                    return View(clientes);
                }
            }
            return View();
        }

        public ActionResult PostClienteAPI()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostClienteAPI(ClienteVM cliente)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44393/api/cliente");
            var postTask = client.PostAsJsonAsync("cliente", cliente);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<ClienteVM>();
                readTask.Wait();

                var insertedStudent = readTask.Result;

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Falha no cadastro do cliente");
            }
            return View();
        }
    }
}


//Install-Package System.Net.Http.Formatting.Extension -Version 5.2.3