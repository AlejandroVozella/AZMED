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
    public class SolpedsController : Controller
    {
        private AzMedEntities db = new AzMedEntities();

        // GET: Solpeds
        public ActionResult Index()
        {
            var solped = db.Solped.Include(s => s.EstadoSolp);
            return View(solped.ToList());
        }

        // GET: Solpeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solped solped = db.Solped.Find(id);
            if (solped == null)
            {
                return HttpNotFound();
            }
            return View(solped);
        }

        // GET: Solpeds/Create
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(db.EstadoSolp, "id", "Nombre");
            return View();
        }

        // POST: Solpeds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Fecha,Estado")] Solped solped)
        {
            if (ModelState.IsValid)
            {
                db.Solped.Add(solped);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado = new SelectList(db.EstadoSolp, "id", "Nombre", solped.Estado);
            return View(solped);
        }

        // GET: Solpeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solped solped = db.Solped.Find(id);
            if (solped == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado = new SelectList(db.EstadoSolp, "id", "Nombre", solped.Estado);
            return View(solped);
        }

        // POST: Solpeds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Fecha,Estado")] Solped solped)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solped).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado = new SelectList(db.EstadoSolp, "id", "Nombre", solped.Estado);
            return View(solped);
        }

        // GET: Solpeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solped solped = db.Solped.Find(id);
            if (solped == null)
            {
                return HttpNotFound();
            }
            return View(solped);
        }

        // POST: Solpeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solped solped = db.Solped.Find(id);
            db.Solped.Remove(solped);
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
