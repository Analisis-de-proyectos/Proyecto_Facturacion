using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Analisis_Proyectos;

namespace Analisis_Proyectos.Controllers
{
    public class modoPagoesController : Controller
    {
        private ventasEntities db = new ventasEntities();

        // GET: modoPagoes
        public ActionResult Index()
        {
            return View(db.modoPagoes.ToList());
        }

        // GET: modoPagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modoPago modoPago = db.modoPagoes.Find(id);
            if (modoPago == null)
            {
                return HttpNotFound();
            }
            return View(modoPago);
        }

        // GET: modoPagoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: modoPagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numPago,nombre,otroDetalles")] modoPago modoPago)
        {
            if (ModelState.IsValid)
            {
                db.modoPagoes.Add(modoPago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modoPago);
        }

        // GET: modoPagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modoPago modoPago = db.modoPagoes.Find(id);
            if (modoPago == null)
            {
                return HttpNotFound();
            }
            return View(modoPago);
        }

        // POST: modoPagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numPago,nombre,otroDetalles")] modoPago modoPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modoPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modoPago);
        }

        // GET: modoPagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modoPago modoPago = db.modoPagoes.Find(id);
            if (modoPago == null)
            {
                return HttpNotFound();
            }
            return View(modoPago);
        }

        // POST: modoPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modoPago modoPago = db.modoPagoes.Find(id);
            db.modoPagoes.Remove(modoPago);
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
