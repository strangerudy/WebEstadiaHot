using Buya.App.UI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Buya.App.UI.Controllers
{
    [Authorize]
    public class QuartosController : Controller
    {
        private EstadiaHotBuyaEntities db = new EstadiaHotBuyaEntities();

        // GET: Quartos
        public ActionResult Index()
        {
            var quarto = db.Quarto.Include(q => q.Estado_Quarto).Include(q => q.Quarto_Tipo);
            return View(quarto.ToList());
        }

        // GET: Quartos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarto quarto = db.Quarto.Find(id);
            if (quarto == null)
            {
                return HttpNotFound();
            }
            return View(quarto);
        }

        // GET: Quartos/Create
        public ActionResult Create()
        {
            ViewBag.Id_Estado_Quarto = new SelectList(db.Estado_Quarto, "Id_Estado_Quarto", "Estado_Quarto1");
            ViewBag.Id_Quarto_Tipo = new SelectList(db.Quarto_Tipo, "Id_Quarto_Tipo", "Quarto_Tipo_Descricao");
            return View();
        }

        // POST: Quartos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Quarto,Descricao,Id_Quarto_Tipo,Id_Estado_Quarto")] Quarto quarto)
        {
            if (ModelState.IsValid)
            {
                db.Quarto.Add(quarto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Estado_Quarto = new SelectList(db.Estado_Quarto, "Id_Estado_Quarto", "Estado_Quarto1", quarto.Id_Estado_Quarto);
            ViewBag.Id_Quarto_Tipo = new SelectList(db.Quarto_Tipo, "Id_Quarto_Tipo", "Quarto_Tipo_Descricao", quarto.Id_Quarto_Tipo);
            return View(quarto);
        }

        // GET: Quartos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarto quarto = db.Quarto.Find(id);
            if (quarto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Estado_Quarto = new SelectList(db.Estado_Quarto, "Id_Estado_Quarto", "Estado_Quarto1", quarto.Id_Estado_Quarto);
            ViewBag.Id_Quarto_Tipo = new SelectList(db.Quarto_Tipo, "Id_Quarto_Tipo", "Quarto_Tipo_Descricao", quarto.Id_Quarto_Tipo);
            return View(quarto);
        }

        // POST: Quartos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Quarto,Descricao,Id_Quarto_Tipo,Id_Estado_Quarto")] Quarto quarto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quarto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Estado_Quarto = new SelectList(db.Estado_Quarto, "Id_Estado_Quarto", "Estado_Quarto1", quarto.Id_Estado_Quarto);
            ViewBag.Id_Quarto_Tipo = new SelectList(db.Quarto_Tipo, "Id_Quarto_Tipo", "Quarto_Tipo_Descricao", quarto.Id_Quarto_Tipo);
            return View(quarto);
        }

        // GET: Quartos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarto quarto = db.Quarto.Find(id);
            if (quarto == null)
            {
                return HttpNotFound();
            }
            return View(quarto);
        }

        // POST: Quartos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quarto quarto = db.Quarto.Find(id);
            db.Quarto.Remove(quarto);
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
