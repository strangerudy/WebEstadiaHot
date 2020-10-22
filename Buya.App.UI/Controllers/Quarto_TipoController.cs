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
    public class Quarto_TipoController : Controller
    {
        private EstadiaHotBuyaEntities db = new EstadiaHotBuyaEntities();

        // GET: Quarto_Tipo
        public ActionResult Index()
        {
            return View(db.Quarto_Tipo.ToList());
        }

        // GET: Quarto_Tipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarto_Tipo quarto_Tipo = db.Quarto_Tipo.Find(id);
            if (quarto_Tipo == null)
            {
                return HttpNotFound();
            }
            return View(quarto_Tipo);
        }

        // GET: Quarto_Tipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quarto_Tipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Quarto_Tipo,Quarto_Tipo_Descricao,Valor_Tipo_Quarto")] Quarto_Tipo quarto_Tipo)
        {
            if (ModelState.IsValid)
            {
                db.Quarto_Tipo.Add(quarto_Tipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quarto_Tipo);
        }

        // GET: Quarto_Tipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarto_Tipo quarto_Tipo = db.Quarto_Tipo.Find(id);
            if (quarto_Tipo == null)
            {
                return HttpNotFound();
            }
            return View(quarto_Tipo);
        }

        // POST: Quarto_Tipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Quarto_Tipo,Quarto_Tipo_Descricao,Valor_Tipo_Quarto")] Quarto_Tipo quarto_Tipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quarto_Tipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quarto_Tipo);
        }

        // GET: Quarto_Tipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarto_Tipo quarto_Tipo = db.Quarto_Tipo.Find(id);
            if (quarto_Tipo == null)
            {
                return HttpNotFound();
            }
            return View(quarto_Tipo);
        }

        // POST: Quarto_Tipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quarto_Tipo quarto_Tipo = db.Quarto_Tipo.Find(id);
            db.Quarto_Tipo.Remove(quarto_Tipo);
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
