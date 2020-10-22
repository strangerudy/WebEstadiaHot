using Buya.App.UI.Models;
using Buya.App.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Buya.App.UI.Controllers
{
    [Authorize]
    public class ReservasController : Controller
    {
        private EstadiaHotBuyaEntities db = new EstadiaHotBuyaEntities();

        // GET: Reservas
        [HttpGet]
        public ActionResult Index()
        {
            //return View(db.SP_ReservaLocalizar(""));
            //var reserva = db.Reserva.Include(r => r.Acesso).Include(r => r.Quarto).Where(busca => busca.Id_Quarto == 1);
            //return View(reserva.ToList());
            return View(ReservaListarTodas(""));
        }

        [HttpPost]
        public ActionResult Index(string parametroBD)
        {
            var usuario = ReservaListarTodas(parametroBD);

            if (usuario == null)
            {
                return View();
            }
            return View("Index", usuario);
        }

        public IQueryable ObterReservasClassificadosPorNome(string nome)
        {
            //return db.Reserva.Include(c => c.Acesso).Include(f => f.Quarto).OrderBy(n => n.Acesso.Email==nome);
            return db.Reserva.Include(c => c.Cliente.Acesso).Include(f => f.Quarto).Where(n => n.Cliente.Acesso.Email.Contains(nome));
        }

        //SqlConnection conexao = new SqlConnection(@"Data source=localhost;Initial Catalog=EstadiaHot;Integrated Security=True;");
        SqlConnection conexao = new SqlConnection(Properties.Settings.Default.buyaCnnString);

        public IEnumerable<ReservasViewModel> ReservaListarTodas(string parametroBD)
        {
            conexao.Open();
            SqlCommand Cmd = new SqlCommand("SP_ReservaLocalizar", conexao);

            Cmd.Parameters.AddWithValue("@Nome_Cliente", parametroBD.Trim());

            Cmd.CommandType = CommandType.StoredProcedure;

            //Cmd.ExecuteNonQuery();

            IList<ReservasViewModel> reservaColecao = new List<ReservasViewModel>();

            //db.SP_ReservaLocalizar(parametroBD);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Cmd);
            
            DataTable dataTableUsuarios = new DataTable();

            sqlDataAdapter.Fill(dataTableUsuarios);

            foreach (DataRow linha in dataTableUsuarios.Rows)
            {
                ReservasViewModel reserva = new ReservasViewModel();

                reserva.Id_Reserva = Convert.ToInt32(linha["Id_Reserva"]);
                reserva.Id_Cliente = Convert.ToInt32(linha["Id_Cliente"]);

                reserva.Id_Quarto = Convert.ToInt32(linha["Id_Quarto"]);
                reserva.Quarto_Tipo_Descricao = Convert.ToString(linha["Quarto_Tipo_Descricao"]);

                reserva.Data_Reserva = Convert.ToDateTime(linha["Data_Reserva"]).Date;

                reserva.Data_Entrada = Convert.ToDateTime(linha["Data_Entrada"]).Date;

                reserva.Email = Convert.ToString(linha["Email"]);
                //reserva.Senha = Convert.ToString(linha["Senha"]);

                reservaColecao.Add(reserva);
            }

            return reservaColecao;
        }

        public ActionResult CheckIn(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Cliente = new SelectList(db.Acesso, "AcessoId", "Email", reserva.Id_Cliente);
            ViewBag.Id_Quarto = new SelectList(db.Quarto, "Id_Quarto", "Descricao", reserva.Id_Quarto);
            return View(reserva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckIn([Bind(Include = "Id_Reserva,Id_Cliente,Id_Quarto,Data_Entrada,Data_Reserva")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                //reserva.Acesso.AcessoId = 1; Funcionário
                
                db.SP_HospedagemInserir(reserva.Id_Reserva, 1, reserva.Data_Entrada, reserva.Data_Reserva);
                // db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Cliente = new SelectList(db.Acesso, "AcessoId", "Email", reserva.Id_Cliente);
            ViewBag.Id_Quarto = new SelectList(db.Quarto, "Id_Quarto", "Descricao", reserva.Id_Quarto); 
            return View(reserva);
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {

            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id_Cliente", "Nome_Cliente");
            ViewBag.Id_Quarto = new SelectList(db.Quarto.Where(b => b.Id_Estado_Quarto==1), "Id_Quarto", "Descricao");

            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Create([Bind(Include = "Id_Reserva,Id_Cliente,Id_Quarto,Data_Entrada")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.SP_ReservaInserir(reserva.Id_Cliente, reserva.Id_Quarto, reserva.Data_Entrada);
                //db.Reserva.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id_Cliente", "Nome_Cliente", reserva.Id_Cliente);
            ViewBag.Id_Quarto = new SelectList(db.Quarto, "Id_Quarto", "Descricao", reserva.Id_Quarto);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Cliente = new SelectList(db.Acesso, "AcessoId", "Email", reserva.Id_Cliente);
            ViewBag.Id_Quarto = new SelectList(db.Quarto, "Id_Quarto", "Descricao", reserva.Id_Quarto);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Reserva,Id_Cliente,Id_Quarto,Data_Entrada")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.SP_ReservaAlterar(reserva.Id_Reserva, reserva.Id_Cliente, reserva.Id_Quarto, reserva.Data_Entrada);
                // db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Cliente = new SelectList(db.Acesso, "AcessoId", "Email", reserva.Id_Cliente);
            ViewBag.Id_Quarto = new SelectList(db.Quarto, "Id_Quarto", "Descricao", reserva.Id_Quarto);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserva reserva = db.Reserva.Find(id);
            db.Reserva.Remove(reserva);
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
    }
}
