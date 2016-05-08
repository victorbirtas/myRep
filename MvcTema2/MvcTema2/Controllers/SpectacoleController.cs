using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcTema2.Models;

namespace MvcTema2.Controllers
{
    public class SpectacoleController : Controller
    {
        private SpectacolDBContext db = new SpectacolDBContext();

        // GET: Spectacole
         [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Spectacole.ToList());
        }

        // GET: Spectacole/Details/5
         [Authorize(Roles = "Admin")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spectacol spectacol = db.Spectacole.Find(id);
            if (spectacol == null)
            {
                return HttpNotFound();
            }
            return View(spectacol);
        }

        // GET: Spectacole/Create
         [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spectacole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Titlul,Regia,Distributia,Premiera,NrBilete")] Spectacol spectacol)
        {
            if (ModelState.IsValid)
            {
                db.Spectacole.Add(spectacol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(spectacol);
        }

        // GET: Spectacole/Edit/5
         [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spectacol spectacol = db.Spectacole.Find(id);
            if (spectacol == null)
            {
                return HttpNotFound();
            }
            return View(spectacol);
        }

        // POST: Spectacole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Titlul,Regia,Distributia,Premiera,NrBilete")] Spectacol spectacol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spectacol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spectacol);
        }

        // GET: Spectacole/Delete/5
         [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spectacol spectacol = db.Spectacole.Find(id);
            if (spectacol == null)
            {
                return HttpNotFound();
            }
            return View(spectacol);
        }

        // POST: Spectacole/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Spectacol spectacol = db.Spectacole.Find(id);
            db.Spectacole.Remove(spectacol);
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
