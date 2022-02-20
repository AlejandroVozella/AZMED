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
    public class PlansController : Controller
    {
        private AzMedEntities db = new AzMedEntities();

        // GET: Plans
        public ActionResult Index()
        {
            var plan = db.Plan.Include(p => p.ObraSocial);
            return View(plan.ToList());
        }

        // GET: Plans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plans/Create
        public ActionResult Create()
        {
            ViewBag.idObraSocial = new SelectList(db.ObraSocial, "id", "Nombre");
            return View();
        }

        // POST: Plans/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre,TipoPlan,idObraSocial")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Plan.Add(plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idObraSocial = new SelectList(db.ObraSocial, "id", "Nombre", plan.idObraSocial);
            return View(plan);
        }

        // GET: Plans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            ViewBag.idObraSocial = new SelectList(db.ObraSocial, "id", "Nombre", plan.idObraSocial);
            return View(plan);
        }

        // POST: Plans/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre,TipoPlan,idObraSocial")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idObraSocial = new SelectList(db.ObraSocial, "id", "Nombre", plan.idObraSocial);
            return View(plan);
        }

        // GET: Plans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plan plan = db.Plan.Find(id);
            db.Plan.Remove(plan);
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
