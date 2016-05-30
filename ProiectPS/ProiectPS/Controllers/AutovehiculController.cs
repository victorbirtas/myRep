using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProiectPS.Models;

namespace ProiectPS.Controllers
{
    public class AutovehiculController : Controller
    {
        private AutovehiculDBContext db = new AutovehiculDBContext();

        // GET: Autovehicul
        [Authorize(Roles = "User")]
        public ActionResult Index()
        {
            return View(db.Autovehicule.ToList());
        }

        // GET: Autovehicul/Details/5
        [Authorize(Roles = "User")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autovehicul autovehicul = db.Autovehicule.Find(id);
            if (autovehicul == null)
            {
                return HttpNotFound();
            }
            return View(autovehicul);
        }

        // GET: Autovehicul/Create
        [Authorize(Roles = "User")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autovehicul/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sasiu,NrInmatriculare,TipVehicul,Marca,Model,CapacitateCilindrica,TipCombustibil,AnFabricatie,Putere,NrLocuri,MasaTotala")] Autovehicul autovehicul)
        {
            if (ModelState.IsValid)
            {
                db.Autovehicule.Add(autovehicul);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autovehicul);
        }

        // GET: Autovehicul/Edit/5
        [Authorize(Roles = "User")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autovehicul autovehicul = db.Autovehicule.Find(id);
            if (autovehicul == null)
            {
                return HttpNotFound();
            }
            return View(autovehicul);
        }

        // POST: Autovehicul/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sasiu,NrInmatriculare,TipVehicul,Marca,Model,CapacitateCilindrica,TipCombustibil,AnFabricatie,Putere,NrLocuri,MasaTotala")] Autovehicul autovehicul)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autovehicul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autovehicul);
        }

        // GET: Autovehicul/Delete/5
        [Authorize(Roles = "User")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autovehicul autovehicul = db.Autovehicule.Find(id);
            if (autovehicul == null)
            {
                return HttpNotFound();
            }
            return View(autovehicul);
        }

        // POST: Autovehicul/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Autovehicul autovehicul = db.Autovehicule.Find(id);
            db.Autovehicule.Remove(autovehicul);
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
