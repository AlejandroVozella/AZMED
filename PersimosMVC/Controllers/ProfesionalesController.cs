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
    public class ProfesionalesController : Controller
    {
        private AzMedEntities db = new AzMedEntities();

        // GET: Profesionales
        public ActionResult Index(string BuscarNombre)
        {
            var profesional = from cr in db.Profesionales select cr;
            if (!String.IsNullOrEmpty(BuscarNombre))
            {
                profesional = profesional.Where(c => c.Profesional.Contains(BuscarNombre));
            }
            //var usuario = db.usuario.Include(u => u.rol);
            //return View(usuario.ToList());
            return View(profesional);
            //return View(db.Especialidad.ToList());
            //var profesionales = db.Profesionales.Include(p => p.Especialidad);
            //return View(profesionales.ToList());
        }

        // GET: Profesionales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesionales profesionales = db.Profesionales.Find(id);
            if (profesionales == null)
            {
                return HttpNotFound();
            }
            return View(profesionales);
        }

        // GET: Profesionales/Create
        public ActionResult Create()
        {
            ViewBag.idEspecialidad = new SelectList(db.Especialidad, "id", "Nombre");
            return View();
        }

        // POST: Profesionales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Profesional,Matricula,idEspecialidad")] Profesionales profesionales)
        {
            if (ModelState.IsValid)
            {
                db.Profesionales.Add(profesionales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEspecialidad = new SelectList(db.Especialidad, "id", "Nombre", profesionales.idEspecialidad);
            return View(profesionales);
        }

        // GET: Profesionales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesionales profesionales = db.Profesionales.Find(id);
            if (profesionales == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEspecialidad = new SelectList(db.Especialidad, "id", "Nombre", profesionales.idEspecialidad);
            return View(profesionales);
        }

        // POST: Profesionales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Profesional,Matricula,idEspecialidad")] Profesionales profesionales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesionales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEspecialidad = new SelectList(db.Especialidad, "id", "Nombre", profesionales.idEspecialidad);
            return View(profesionales);
        }

        // GET: Profesionales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesionales profesionales = db.Profesionales.Find(id);
            if (profesionales == null)
            {
                return HttpNotFound();
            }
            return View(profesionales);
        }

        // POST: Profesionales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profesionales profesionales = db.Profesionales.Find(id);
            db.Profesionales.Remove(profesionales);
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
