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
    public class ProprietarController : Controller
    {
        private ProprietarDBContext db = new ProprietarDBContext();

        // GET: Proprietar
        [Authorize(Roles = "User")]
        public ActionResult Index()
        {
            return View(db.Proprietari.ToList());
        }

        // GET: Proprietar/Details/5
        [Authorize(Roles = "User")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietar proprietar = db.Proprietari.Find(id);
            if (proprietar == null)
            {
                return HttpNotFound();
            }
            return View(proprietar);
        }

        // GET: Proprietar/Create
        [Authorize(Roles = "User")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proprietar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cnp,Nume,Prenume,Adresa")] Proprietar proprietar)
        {
            if (ModelState.IsValid)
            {
                db.Proprietari.Add(proprietar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proprietar);
        }

        // GET: Proprietar/Edit/5
        [Authorize(Roles = "User")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietar proprietar = db.Proprietari.Find(id);
            if (proprietar == null)
            {
                return HttpNotFound();
            }
            return View(proprietar);
        }

        // POST: Proprietar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cnp,Nume,Prenume,Adresa")] Proprietar proprietar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proprietar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proprietar);
        }

        // GET: Proprietar/Delete/5
        [Authorize(Roles = "User")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietar proprietar = db.Proprietari.Find(id);
            if (proprietar == null)
            {
                return HttpNotFound();
            }
            return View(proprietar);
        }

        // POST: Proprietar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Proprietar proprietar = db.Proprietari.Find(id);
            db.Proprietari.Remove(proprietar);
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
