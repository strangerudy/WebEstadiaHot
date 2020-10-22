using Buya.App.UI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebEstadiaHot.UsuarioActual;


namespace Buya.App.UI.Controllers
{
    [Authorize]
    public class ReservasClienteController : Controller
    {
        private EstadiaHotBuyaEntities db = new EstadiaHotBuyaEntities();

        // GET: ReservasCliente
        public ActionResult Index()
        {
            var reserva = db.Reserva.Include(r => r.Cliente.Acesso).Include(r => r.Quarto).Where(es=>es.Estado == false && es.Id_Cliente==DadosUsuarioActual.Id_Usuario);
            return View(reserva.ToList());
        }

        // GET: ReservasCliente/Details/5
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

        // GET: ReservasCliente/Create
        public ActionResult Create()
        {
            ViewBag.Id_Cliente = new SelectList(db.Acesso.Where(cli=>cli.AcessoId==DadosUsuarioActual.Id_Usuario), "AcessoId", "Email");

            ViewBag.Id_Quarto = new SelectList(db.Quarto.Where(b => b.Id_Estado_Quarto == 1), "Id_Quarto", "Descricao");
            return View();
        }

        // POST: ReservasCliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Reserva,Id_Cliente,Id_Quarto,Data_Entrada")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.SP_ReservaInserir(DadosUsuarioActual.Id_Usuario, reserva.Id_Quarto, reserva.Data_Entrada);
                //db.Reserva.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cliente = new SelectList(db.Acesso, "AcessoId", "Email", reserva.Id_Cliente);
            ViewBag.Id_Quarto = new SelectList(db.Quarto, "Id_Quarto", "Descricao", reserva.Id_Quarto);
            return View(reserva);
        }

        // GET: ReservasCliente/Edit/5
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

        // POST: ReservasCliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Reserva,Id_Cliente,Id_Quarto,Data_Reserva,Data_Entrada,Estado")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Cliente = new SelectList(db.Acesso, "AcessoId", "Email", reserva.Id_Cliente);
            ViewBag.Id_Quarto = new SelectList(db.Quarto, "Id_Quarto", "Descricao", reserva.Id_Quarto);
            return View(reserva);
        }

        // GET: ReservasCliente/Delete/5
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

        // POST: ReservasCliente/Delete/5
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
