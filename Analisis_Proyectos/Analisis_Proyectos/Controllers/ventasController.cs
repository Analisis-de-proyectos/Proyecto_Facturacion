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
    public class ventasController : Controller
    {
        private ventasEntities db = new ventasEntities();

        // GET: ventas
        public ActionResult Index()
        {
            var ventas = db.ventas.Include(v => v.cliente).Include(v => v.vendedor);
            return View(ventas.ToList());
        }

        // GET: ventas/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venta venta = db.ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: ventas/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.clientes, "idCliente", "nombre");
            ViewBag.idVendedor = new SelectList(db.vendedors, "idVendedor", "nombre");
            return View();
        }

        // POST: ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVenta,total,idCliente,idVendedor,fecha,IVA")] venta venta)
        {
            if (ModelState.IsValid)
            {
                db.ventas.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.clientes, "idCliente", "nombre", venta.idCliente);
            ViewBag.idVendedor = new SelectList(db.vendedors, "idVendedor", "nombre", venta.idVendedor);
            return View(venta);
        }

        // GET: ventas/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venta venta = db.ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.clientes, "idCliente", "nombre", venta.idCliente);
            ViewBag.idVendedor = new SelectList(db.vendedors, "idVendedor", "nombre", venta.idVendedor);
            return View(venta);
        }

        // POST: ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVenta,total,idCliente,idVendedor,fecha,IVA")] venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.clientes, "idCliente", "nombre", venta.idCliente);
            ViewBag.idVendedor = new SelectList(db.vendedors, "idVendedor", "nombre", venta.idVendedor);
            return View(venta);
        }

        // GET: ventas/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venta venta = db.ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            venta venta = db.ventas.Find(id);
            db.ventas.Remove(venta);
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
