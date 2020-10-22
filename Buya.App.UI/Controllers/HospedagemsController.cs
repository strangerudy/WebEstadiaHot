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
    public class HospedagemsController : Controller
    {
        private EstadiaHotBuyaEntities db = new EstadiaHotBuyaEntities();

        // GET: Hospedagems
        public ActionResult Index()
        {
            var hospedagem = db.Hospedagem.Include(h => h.Funcionario).Include(h => h.Reserva).Where(hospedes=>hospedes.Estado==false);
            return View(hospedagem.ToList());
        }

        SqlConnection conexao = new SqlConnection(@"Data source=localhost;Initial Catalog=EstadiaHot;Integrated Security=True;");

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

        public ActionResult CheckOut(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospedagem hospedagem = db.Hospedagem.Find(id);
            if (hospedagem == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Cliente = new SelectList(db.Acesso, "AcessoId", "Email", hospedagem.Reserva.Id_Cliente);
            ViewBag.Id_Reserva = new SelectList(db.Reserva, "Id_Reserva", "Id_Reserva", hospedagem.Id_Reserva);
            return View(hospedagem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut([Bind(Include = "Id_Hospedagem,Id_Funcionario,Id_Reserva,Data_CheckIn,Data_CheckOut")] Hospedagem hospedagem)
        {
            if (ModelState.IsValid)
            {
                //reserva.Acesso.AcessoId = 1; Funcionário

                var us = db.Reserva.Include(q => q.Cliente).Where(a => a.Id_Reserva == hospedagem.Id_Reserva).FirstOrDefault();

                double dias = hospedagem.Data_CheckOut.Value.Subtract(hospedagem.Data_CheckIn).TotalDays;

                decimal precoDia = Convert.ToInt32(dias) * us.Quarto.Quarto_Tipo.Valor_Tipo_Quarto;

                db.SP_HospedagemCheckOut(hospedagem.Id_Hospedagem, 1, precoDia);
                // db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Id_Cliente = new SelectList(db.Acesso, "AcessoId", "Email", reserva.Id_Cliente);
            //ViewBag.Id_Quarto = new SelectList(db.Quarto, "Id_Quarto", "Descricao", reserva.Id_Quarto);
            return View(hospedagem);
        }

        // GET: Hospedagems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospedagem hospedagem = db.Hospedagem.Find(id);
            if (hospedagem == null)
            {
                return HttpNotFound();
            }
            return View(hospedagem);
        }

        // GET: Hospedagems/Create
        public ActionResult Create()
        {
            ViewBag.Id_Funcionario = new SelectList(db.Acesso, "AcessoId", "Email");
            ViewBag.Id_Reserva = new SelectList(db.Reserva, "Id_Reserva", "Id_Reserva");
            return View();
        }

        // POST: Hospedagems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Hospedagem,Id_Reserva,Id_Funcionario,Data_CheckIn,Data_CheckOut")] Hospedagem hospedagem)
        {
            if (ModelState.IsValid)
            {
                db.Hospedagem.Add(hospedagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Funcionario = new SelectList(db.Acesso, "AcessoId", "Email", hospedagem.Id_Funcionario);
            ViewBag.Id_Reserva = new SelectList(db.Reserva, "Id_Reserva", "Id_Reserva", hospedagem.Id_Reserva);
            return View(hospedagem);
        }

        // GET: Hospedagems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospedagem hospedagem = db.Hospedagem.Find(id);
            if (hospedagem == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Funcionario = new SelectList(db.Acesso, "AcessoId", "Email", hospedagem.Id_Funcionario);
            ViewBag.Id_Reserva = new SelectList(db.Reserva, "Id_Reserva", "Id_Reserva", hospedagem.Id_Reserva);
            return View(hospedagem);
        }

        // POST: Hospedagems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Hospedagem,Id_Reserva,Id_Funcionario,Data_CheckIn,Data_CheckOut,Estado")] Hospedagem hospedagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospedagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Funcionario = new SelectList(db.Acesso, "AcessoId", "Email", hospedagem.Id_Funcionario);
            ViewBag.Id_Reserva = new SelectList(db.Reserva, "Id_Reserva", "Id_Reserva", hospedagem.Id_Reserva);
            return View(hospedagem);
        }

        // GET: Hospedagems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospedagem hospedagem = db.Hospedagem.Find(id);
            if (hospedagem == null)
            {
                return HttpNotFound();
            }
            return View(hospedagem);
        }

        // POST: Hospedagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hospedagem hospedagem = db.Hospedagem.Find(id);
            db.Hospedagem.Remove(hospedagem);
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
