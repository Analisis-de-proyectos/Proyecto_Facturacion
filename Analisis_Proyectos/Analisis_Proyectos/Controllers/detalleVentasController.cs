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
    public class detalleVentasController : Controller
    {
        private ventasEntities db = new ventasEntities();

        // GET: detalleVentas
        public ActionResult Index()
        {
            var detalleVentas = db.detalleVentas.Include(d => d.venta).Include(d => d.factura).Include(d => d.producto);
            return View(detalleVentas.ToList());
        }

        // GET: detalleVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalleVenta detalleVenta = db.detalleVentas.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            return View(detalleVenta);
        }

        // GET: detalleVentas/Create
        public ActionResult Create()
        {
            ViewBag.idVenta = new SelectList(db.ventas, "idVenta", "idVendedor");
            ViewBag.numFactura = new SelectList(db.facturas, "numFactura", "numFactura");
            ViewBag.idProducto = new SelectList(db.productoes, "idProducto", "nombre");
            return View();
        }

        // POST: detalleVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDetalle,numFactura,idVenta,subTotal,idProducto,descuento,cantidad")] detalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                db.detalleVentas.Add(detalleVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idVenta = new SelectList(db.ventas, "idVenta", "idVendedor", detalleVenta.idVenta);
            ViewBag.numFactura = new SelectList(db.facturas, "numFactura", "numFactura", detalleVenta.numFactura);
            ViewBag.idProducto = new SelectList(db.productoes, "idProducto", "nombre", detalleVenta.idProducto);
            return View(detalleVenta);
        }

        // GET: detalleVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalleVenta detalleVenta = db.detalleVentas.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idVenta = new SelectList(db.ventas, "idVenta", "idVendedor", detalleVenta.idVenta);
            ViewBag.numFactura = new SelectList(db.facturas, "numFactura", "numFactura", detalleVenta.numFactura);
            ViewBag.idProducto = new SelectList(db.productoes, "idProducto", "nombre", detalleVenta.idProducto);
            return View(detalleVenta);
        }

        // POST: detalleVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDetalle,numFactura,idVenta,subTotal,idProducto,descuento,cantidad")] detalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idVenta = new SelectList(db.ventas, "idVenta", "idVendedor", detalleVenta.idVenta);
            ViewBag.numFactura = new SelectList(db.facturas, "numFactura", "numFactura", detalleVenta.numFactura);
            ViewBag.idProducto = new SelectList(db.productoes, "idProducto", "nombre", detalleVenta.idProducto);
            return View(detalleVenta);
        }

        // GET: detalleVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalleVenta detalleVenta = db.detalleVentas.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            return View(detalleVenta);
        }

        // POST: detalleVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detalleVenta detalleVenta = db.detalleVentas.Find(id);
            db.detalleVentas.Remove(detalleVenta);
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
