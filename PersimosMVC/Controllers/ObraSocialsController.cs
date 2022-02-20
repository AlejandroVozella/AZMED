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
    public class ObraSocialsController : Controller
    {
        private AzMedEntities db = new AzMedEntities();

        // GET: ObraSocials
        public ActionResult Index(string BuscarNombre)
        {
            var obrasocial = from cr in db.ObraSocial select cr;
            if (!String.IsNullOrEmpty(BuscarNombre))
            {
                obrasocial = obrasocial.Where(c => c.Nombre.Contains(BuscarNombre));
            }
            //var usuario = db.usuario.Include(u => u.rol);
            //return View(usuario.ToList());
            return View(obrasocial);
            //return View(db.Especialidad.ToList());
            //return View(db.ObraSocial.ToList());
        }

        // GET: ObraSocials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObraSocial obraSocial = db.ObraSocial.Find(id);
            if (obraSocial == null)
            {
                return HttpNotFound();
            }
            return View(obraSocial);
        }

        // GET: ObraSocials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ObraSocials/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre,Cuil,Contacto")] ObraSocial obraSocial)
        {
            if (ModelState.IsValid)
            {
                db.ObraSocial.Add(obraSocial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obraSocial);
        }

        // GET: ObraSocials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObraSocial obraSocial = db.ObraSocial.Find(id);
            if (obraSocial == null)
            {
                return HttpNotFound();
            }
            return View(obraSocial);
        }

        // POST: ObraSocials/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre,Cuil,Contacto")] ObraSocial obraSocial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obraSocial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obraSocial);
        }

        // GET: ObraSocials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObraSocial obraSocial = db.ObraSocial.Find(id);
            if (obraSocial == null)
            {
                return HttpNotFound();
            }
            return View(obraSocial);
        }

        // POST: ObraSocials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObraSocial obraSocial = db.ObraSocial.Find(id);
            db.ObraSocial.Remove(obraSocial);
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
