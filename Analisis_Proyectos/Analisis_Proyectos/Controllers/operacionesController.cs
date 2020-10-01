using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Analisis_Proyectos.Models;

namespace Analisis_Proyectos.Controllers
{
    public class operacionesController : Controller
    {
        private ventasEntities2 db = new ventasEntities2();

        // GET: operaciones
        public ActionResult Index()
        {
            var operaciones = db.operaciones.Include(o => o.modulo);
            return View(operaciones.ToList());
        }

        // GET: operaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            operacione operacione = db.operaciones.Find(id);
            if (operacione == null)
            {
                return HttpNotFound();
            }
            return View(operacione);
        }

        // GET: operaciones/Create
        public ActionResult Create()
        {
            ViewBag.idModulo = new SelectList(db.moduloes, "id", "nombre");
            return View();
        }

        // POST: operaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,idModulo")] operacione operacione)
        {
            if (ModelState.IsValid)
            {
                db.operaciones.Add(operacione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idModulo = new SelectList(db.moduloes, "id", "nombre", operacione.idModulo);
            return View(operacione);
        }

        // GET: operaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            operacione operacione = db.operaciones.Find(id);
            if (operacione == null)
            {
                return HttpNotFound();
            }
            ViewBag.idModulo = new SelectList(db.moduloes, "id", "nombre", operacione.idModulo);
            return View(operacione);
        }

        // POST: operaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,idModulo")] operacione operacione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operacione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idModulo = new SelectList(db.moduloes, "id", "nombre", operacione.idModulo);
            return View(operacione);
        }

        // GET: operaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            operacione operacione = db.operaciones.Find(id);
            if (operacione == null)
            {
                return HttpNotFound();
            }
            return View(operacione);
        }

        // POST: operaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            operacione operacione = db.operaciones.Find(id);
            db.operaciones.Remove(operacione);
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
