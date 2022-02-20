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
    public class TurnosEstudiosController : Controller
    {
        private AzMedEntities db = new AzMedEntities();

        // GET: TurnosEstudios
        public ActionResult Index()
        {
            var turnosEstudios = db.TurnosEstudios.Include(t => t.Estudios).Include(t => t.Pacientes);
            return View(turnosEstudios.ToList());
        }

        // GET: TurnosEstudios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurnosEstudios turnosEstudios = db.TurnosEstudios.Find(id);
            if (turnosEstudios == null)
            {
                return HttpNotFound();
            }
            return View(turnosEstudios);
        }

        // GET: TurnosEstudios/Create
        public ActionResult Create()
        {
            ViewBag.Tipo_Estudios = new SelectList(db.Estudios, "id", "Nombre");
            ViewBag.Paciente = new SelectList(db.Pacientes, "id", "Paciente");
            return View();
        }

        // POST: TurnosEstudios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Tipo_Estudios,Paciente")] TurnosEstudios turnosEstudios)
        {
            if (ModelState.IsValid)
            {
                db.TurnosEstudios.Add(turnosEstudios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo_Estudios = new SelectList(db.Estudios, "id", "Nombre", turnosEstudios.Tipo_Estudios);
            ViewBag.Paciente = new SelectList(db.Pacientes, "id", "Paciente", turnosEstudios.Paciente);
            return View(turnosEstudios);
        }

        // GET: TurnosEstudios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurnosEstudios turnosEstudios = db.TurnosEstudios.Find(id);
            if (turnosEstudios == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo_Estudios = new SelectList(db.Estudios, "id", "Nombre", turnosEstudios.Tipo_Estudios);
            ViewBag.Paciente = new SelectList(db.Pacientes, "id", "Paciente", turnosEstudios.Paciente);
            return View(turnosEstudios);
        }

        // POST: TurnosEstudios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Tipo_Estudios,Paciente")] TurnosEstudios turnosEstudios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turnosEstudios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo_Estudios = new SelectList(db.Estudios, "id", "Nombre", turnosEstudios.Tipo_Estudios);
            ViewBag.Paciente = new SelectList(db.Pacientes, "id", "Paciente", turnosEstudios.Paciente);
            return View(turnosEstudios);
        }

        // GET: TurnosEstudios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurnosEstudios turnosEstudios = db.TurnosEstudios.Find(id);
            if (turnosEstudios == null)
            {
                return HttpNotFound();
            }
            return View(turnosEstudios);
        }

        // POST: TurnosEstudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TurnosEstudios turnosEstudios = db.TurnosEstudios.Find(id);
            db.TurnosEstudios.Remove(turnosEstudios);
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
