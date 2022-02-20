using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersimosMVC.Models;

namespace PersimosMVC.Controllers
{
    public class CotizacionesController : Controller
    {
        private AzMedEntities db = new AzMedEntities();

        // GET: Cotizaciones
        public ActionResult Index()
        {
            var cotizaciones = db.Cotizaciones.Include(c => c.Solped).Include(c => c.Proveedor1);
            return View(cotizaciones.ToList());
        }

        // GET: Cotizaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizaciones cotizaciones = db.Cotizaciones.Find(id);
            if (cotizaciones == null)
            {
                return HttpNotFound();
            }
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Create
        public ActionResult Create()
        {
            ViewBag.Solp = new SelectList(db.Solped, "id", "id");
            ViewBag.Proveedor = new SelectList(db.Proveedor, "id", "nombre");
            return View();
        }

        // POST: Cotizaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Fecha,Estado,Precio_Unitario,Proveedor,Solp")] Cotizaciones cotizaciones)
        {
            if (ModelState.IsValid)
            {
                db.Cotizaciones.Add(cotizaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Solp = new SelectList(db.Solped, "id", "id", cotizaciones.Solp);
            ViewBag.Proveedor = new SelectList(db.Proveedor, "id", "nombre", cotizaciones.Proveedor);
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizaciones cotizaciones = db.Cotizaciones.Find(id);
            if (cotizaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Solp = new SelectList(db.Solped, "id", "id", cotizaciones.Solp);
            ViewBag.Proveedor = new SelectList(db.Proveedor, "id", "nombre", cotizaciones.Proveedor);
            return View(cotizaciones);
        }

        // POST: Cotizaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Fecha,Estado,Precio_Unitario,Proveedor,Solp")] Cotizaciones cotizaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Solp = new SelectList(db.Solped, "id", "id", cotizaciones.Solp);
            ViewBag.Proveedor = new SelectList(db.Proveedor, "id", "nombre", cotizaciones.Proveedor);
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizaciones cotizaciones = db.Cotizaciones.Find(id);
            if (cotizaciones == null)
            {
                return HttpNotFound();
            }
            return View(cotizaciones);
        }

        // POST: Cotizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cotizaciones cotizaciones = db.Cotizaciones.Find(id);
            db.Cotizaciones.Remove(cotizaciones);
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
