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
    public class TurnosController : Controller
    {
        private AzMedEntities db = new AzMedEntities();

        // GET: Turnos
        public ActionResult Index()
        {
            var turnos = db.Turnos.Include(t => t.Pacientes).Include(t => t.Profesionales);
            return View(turnos.ToList());
        }

        // GET: Turnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turnos turnos = db.Turnos.Find(id);
            if (turnos == null)
            {
                return HttpNotFound();
            }
            return View(turnos);
        }

        // GET: Turnos/Create
        public ActionResult Create()
        {
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "id", "Paciente");
            ViewBag.idProfesional = new SelectList(db.Profesionales, "id", "Profesional");
            return View();
        }

        // POST: Turnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre,IdPaciente,idProfesional,Fecha")] Turnos turnos)
        {
            if (ModelState.IsValid)
            {
                db.Turnos.Add(turnos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPaciente = new SelectList(db.Pacientes, "id", "Paciente", turnos.IdPaciente);
            ViewBag.idProfesional = new SelectList(db.Profesionales, "id", "Profesional", turnos.idProfesional);
            return View(turnos);
        }

        // GET: Turnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turnos turnos = db.Turnos.Find(id);
            if (turnos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "id", "Paciente", turnos.IdPaciente);
            ViewBag.idProfesional = new SelectList(db.Profesionales, "id", "Profesional", turnos.idProfesional);
            return View(turnos);
        }

        // POST: Turnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre,IdPaciente,idProfesional,Fecha")] Turnos turnos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turnos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "id", "Paciente", turnos.IdPaciente);
            ViewBag.idProfesional = new SelectList(db.Profesionales, "id", "Profesional", turnos.idProfesional);
            return View(turnos);
        }

        // GET: Turnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turnos turnos = db.Turnos.Find(id);
            if (turnos == null)
            {
                return HttpNotFound();
            }
            return View(turnos);
        }

        // POST: Turnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Turnos turnos = db.Turnos.Find(id);
            db.Turnos.Remove(turnos);
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
