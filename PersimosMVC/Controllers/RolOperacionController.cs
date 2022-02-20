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
    public class RolOperacionController : Controller
    {
        private AzMedEntities db = new AzMedEntities();

        // GET: RolOperacion
        public ActionResult Index()
        {
            var rol_operacion = db.rol_operacion.Include(r => r.operaciones).Include(r => r.rol);
            return View(rol_operacion.ToList());
        }

        // GET: RolOperacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            if (rol_operacion == null)
            {
                return HttpNotFound();
            }
            return View(rol_operacion);
        }

        // GET: RolOperacion/Create
        public ActionResult Create()
        {
            ViewBag.idOperacion = new SelectList(db.operaciones, "id", "nombre");
            ViewBag.idRol = new SelectList(db.rol, "id", "nombre");
            return View();
        }

        // POST: RolOperacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idRol,idOperacion")] rol_operacion rol_operacion)
        {
            if (ModelState.IsValid)
            {
                db.rol_operacion.Add(rol_operacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idOperacion = new SelectList(db.operaciones, "id", "nombre", rol_operacion.idOperacion);
            ViewBag.idRol = new SelectList(db.rol, "id", "nombre", rol_operacion.idRol);
            return View(rol_operacion);
        }

        // GET: RolOperacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            if (rol_operacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idOperacion = new SelectList(db.operaciones, "id", "nombre", rol_operacion.idOperacion);
            ViewBag.idRol = new SelectList(db.rol, "id", "nombre", rol_operacion.idRol);
            return View(rol_operacion);
        }

        // POST: RolOperacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idRol,idOperacion")] rol_operacion rol_operacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol_operacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idOperacion = new SelectList(db.operaciones, "id", "nombre", rol_operacion.idOperacion);
            ViewBag.idRol = new SelectList(db.rol, "id", "nombre", rol_operacion.idRol);
            return View(rol_operacion);
        }

        // GET: RolOperacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            if (rol_operacion == null)
            {
                return HttpNotFound();
            }
            return View(rol_operacion);
        }

        // POST: RolOperacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            db.rol_operacion.Remove(rol_operacion);
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
