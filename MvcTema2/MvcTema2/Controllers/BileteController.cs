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
    public class BileteController : Controller
    {
        private BiletDBContext db = new BiletDBContext();

        // GET: Bilete
          [Authorize(Roles = "Angajat")]
        public ActionResult Index(string spectacoleTitlu)
        {
            var bilete = from b in db.Bilete select b;

            /*
           var spectacoleList = new List<string>();
           var SpectacoleQry = from d in db2.Spectacole
                          orderby d.Titlul
                          select d.Titlul;

           spectacoleList.AddRange(SpectacoleQry.Distinct());
           ViewBag.spectacoleTitlu = new SelectList(spectacoleList);
             * */

            if (!String.IsNullOrEmpty(spectacoleTitlu))
            {
                bilete = bilete.Where(s => s.Spectacol.Contains(spectacoleTitlu));
            }



            return View(bilete);
        }

        // GET: Bilete/Details/5
        [Authorize(Roles = "Angajat")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilet bilet = db.Bilete.Find(id);
            if (bilet == null)
            {
                return HttpNotFound();
            }
            return View(bilet);
        }

        // GET: Bilete/Create
         [Authorize(Roles = "Angajat")]
        public ActionResult Create()
        {
             /*
            SpectacolDBContext db2 = new SpectacolDBContext();

            var spectacoleList = new List<string>();
            var SpectacoleQry = from d in db2.Spectacole
                                orderby d.Titlul
                                select d.Titlul;

            spectacoleList.AddRange(SpectacoleQry.Distinct());
            ViewBag.spectacoleTitlu = new SelectList(spectacoleList);
              */


            return View();
        }

        // POST: Bilete/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Angajat")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Spectacol,Rand,Numar")] Bilet bilet)
        {
            SpectacolDBContext db2 = new SpectacolDBContext();

            if (ModelState.IsValid)
            {
                string x = bilet.Spectacol;
                var spectacole = from m in db2.Spectacole
                             select m;

                var spectacole2 = from m in db.Bilete
                                  select m;

                var nrb = from m in db2.Spectacole where m.Titlul == bilet.Spectacol
                                 select m.NrBilete;

                int nrBileteDeVanzare = nrb.First(); 
                spectacole = spectacole.Where(s => s.Titlul.Contains(x));
                spectacole2 = spectacole2.Where(s => s.Spectacol.Contains(x));
             
                int count1 = spectacole.Count();
                int bileteVandute = spectacole2.Count();

                //constrangere rand si loc

                int rand = bilet.Rand;
                int numar = bilet.Numar;
                var randNumar = spectacole2.Where(s => s.Rand == rand && s.Numar == numar);

              
                if (count1 != 0 && (nrBileteDeVanzare > bileteVandute) && (randNumar.Count() == 0))
                {
                    db.Bilete.Add(bilet);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(bilet);
        }

        // GET: Bilete/Edit/5
        [Authorize(Roles = "Angajat")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilet bilet = db.Bilete.Find(id);
            if (bilet == null)
            {
                return HttpNotFound();
            }
            return View(bilet);
        }

        // POST: Bilete/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Spectacol,Rand,Numar")] Bilet bilet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bilet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bilet);
        }

        // GET: Bilete/Delete/5
        [Authorize(Roles = "Angajat")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilet bilet = db.Bilete.Find(id);
            if (bilet == null)
            {
                return HttpNotFound();
            }
            return View(bilet);
        }

        // POST: Bilete/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Angajat")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bilet bilet = db.Bilete.Find(id);
            db.Bilete.Remove(bilet);
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
