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
    public class facturasController : Controller
    {
        private ventasEntities db = new ventasEntities();

        // GET: facturas
        public ActionResult Index()
        {
            var facturas = db.facturas.Include(f => f.modoPago);
            return View(facturas.ToList());
        }

        // GET: facturas/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: facturas/Create
        public ActionResult Create()
        {
            ViewBag.numPago = new SelectList(db.modoPagoes, "numPago", "nombre");
            return View();
        }

        // POST: facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numFactura,fecha,IVA,total,numPago,descuento")] factura factura)
        {
            if (ModelState.IsValid)
            {
                db.facturas.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.numPago = new SelectList(db.modoPagoes, "numPago", "nombre", factura.numPago);
            return View(factura);
        }

        // GET: facturas/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.numPago = new SelectList(db.modoPagoes, "numPago", "nombre", factura.numPago);
            return View(factura);
        }

        // POST: facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numFactura,fecha,IVA,total,numPago,descuento")] factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.numPago = new SelectList(db.modoPagoes, "numPago", "nombre", factura.numPago);
            return View(factura);
        }

        // GET: facturas/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            factura factura = db.facturas.Find(id);
            db.facturas.Remove(factura);
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
