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
    public class operacionesController : Controller
    {
        private AzMedEntities db = new AzMedEntities();

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
            operaciones operaciones = db.operaciones.Find(id);
            if (operaciones == null)
            {
                return HttpNotFound();
            }
            return View(operaciones);
        }

        // GET: operaciones/Create
        public ActionResult Create()
        {
            ViewBag.idModulo = new SelectList(db.modulo, "id", "nombre");
            return View();
        }

        // POST: operaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,idModulo")] operaciones operaciones)
        {
            if (ModelState.IsValid)
            {
                db.operaciones.Add(operaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idModulo = new SelectList(db.modulo, "id", "nombre", operaciones.idModulo);
            return View(operaciones);
        }

        // GET: operaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            operaciones operaciones = db.operaciones.Find(id);
            if (operaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.idModulo = new SelectList(db.modulo, "id", "nombre", operaciones.idModulo);
            return View(operaciones);
        }

        // POST: operaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,idModulo")] operaciones operaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idModulo = new SelectList(db.modulo, "id", "nombre", operaciones.idModulo);
            return View(operaciones);
        }

        // GET: operaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            operaciones operaciones = db.operaciones.Find(id);
            if (operaciones == null)
            {
                return HttpNotFound();
            }
            return View(operaciones);
        }

        // POST: operaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            operaciones operaciones = db.operaciones.Find(id);
            db.operaciones.Remove(operaciones);
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
