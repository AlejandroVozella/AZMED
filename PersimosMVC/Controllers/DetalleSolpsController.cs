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
    public class DetalleSolpsController : Controller
    {
        private AzMedEntities db = new AzMedEntities();

        // GET: DetalleSolps
        public ActionResult Index()
        {
            var detalleSolp = db.DetalleSolp.Include(d => d.Solped1).Include(d => d.Material1);
            return View(detalleSolp.ToList());
        }

        // GET: DetalleSolps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleSolp detalleSolp = db.DetalleSolp.Find(id);
            if (detalleSolp == null)
            {
                return HttpNotFound();
            }
            return View(detalleSolp);
        }

        // GET: DetalleSolps/Create
        public ActionResult Create()
        {
            ViewBag.Solped = new SelectList(db.Solped, "id", "id");
            ViewBag.Material = new SelectList(db.Material, "id", "Nombre");
            return View();
        }

        // POST: DetalleSolps/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Solped,Material,Cantidad")] DetalleSolp detalleSolp)
        {
            if (ModelState.IsValid)
            {
                db.DetalleSolp.Add(detalleSolp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Solped = new SelectList(db.Solped, "id", "id", detalleSolp.Solped);
            ViewBag.Material = new SelectList(db.Material, "id", "Nombre", detalleSolp.Material);
            return View(detalleSolp);
        }

        // GET: DetalleSolps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleSolp detalleSolp = db.DetalleSolp.Find(id);
            if (detalleSolp == null)
            {
                return HttpNotFound();
            }
            ViewBag.Solped = new SelectList(db.Solped, "id", "id", detalleSolp.Solped);
            ViewBag.Material = new SelectList(db.Material, "id", "Nombre", detalleSolp.Material);
            return View(detalleSolp);
        }

        // POST: DetalleSolps/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Solped,Material,Cantidad")] DetalleSolp detalleSolp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleSolp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Solped = new SelectList(db.Solped, "id", "id", detalleSolp.Solped);
            ViewBag.Material = new SelectList(db.Material, "id", "Nombre", detalleSolp.Material);
            return View(detalleSolp);
        }

        // GET: DetalleSolps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleSolp detalleSolp = db.DetalleSolp.Find(id);
            if (detalleSolp == null)
            {
                return HttpNotFound();
            }
            return View(detalleSolp);
        }

        // POST: DetalleSolps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleSolp detalleSolp = db.DetalleSolp.Find(id);
            db.DetalleSolp.Remove(detalleSolp);
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
