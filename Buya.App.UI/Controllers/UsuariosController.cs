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
    public class UsuariosController : Controller
    {
        private EstadiaHotBuyaEntities db = new EstadiaHotBuyaEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var acesso = db.Acesso.Include(a => a.AcessoTipo);
            return View(acesso.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acesso acesso = db.Acesso.Find(id);
            if (acesso == null)
            {
                return HttpNotFound();
            }
            return View(acesso);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.AcessoTipoId = new SelectList(db.AcessoTipo, "AcessoTipoId", "AcessoTipo1");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AcessoId,Email,Senha,AcessoTipoId")] Acesso acesso)
        {
            if (ModelState.IsValid)
            {
                db.Acesso.Add(acesso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcessoTipoId = new SelectList(db.AcessoTipo, "AcessoTipoId", "AcessoTipo1", acesso.AcessoTipoId);
            return View(acesso);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acesso acesso = db.Acesso.Find(id);
            if (acesso == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcessoTipoId = new SelectList(db.AcessoTipo, "AcessoTipoId", "AcessoTipo1", acesso.AcessoTipoId);
            return View(acesso);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AcessoId,Email,Senha,AcessoTipoId")] Acesso acesso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acesso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcessoTipoId = new SelectList(db.AcessoTipo, "AcessoTipoId", "AcessoTipo1", acesso.AcessoTipoId);
            return View(acesso);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acesso acesso = db.Acesso.Find(id);
            if (acesso == null)
            {
                return HttpNotFound();
            }
            return View(acesso);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acesso acesso = db.Acesso.Find(id);
            db.Acesso.Remove(acesso);
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
