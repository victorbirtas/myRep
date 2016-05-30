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
    public class AsigurareController : Controller
    {
        private AsigurareDBContext db = new AsigurareDBContext();

        [Authorize(Roles = "User")]
        public ActionResult Export(String exporterType)
        {

            ExporterFactory exporterFactory = new ExporterFactory();
            Exporter exporter = exporterFactory.getExporter(exporterType);
            exporter.export();
            // MessageBox.Show("Export cu succes");
            //  return View();

            return View();
        }


        // GET: Asigurare
        [Authorize(Roles = "User")]
        public ActionResult Index()
        {
            return View(db.Asigurari.ToList());
        }

        // GET: Asigurare/Details/5
        [Authorize(Roles = "User")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asigurare asigurare = db.Asigurari.Find(id);
            if (asigurare == null)
            {
                return HttpNotFound();
            }
            return View(asigurare);
        }

        // GET: Asigurare/Create
        [Authorize(Roles = "User")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asigurare/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NrInmatriculare,Proprietar,DataValabilitate,Durata")] Asigurare asigurare)
        {
            ProprietarDBContext dbp = new ProprietarDBContext();
            AutovehiculDBContext dba = new AutovehiculDBContext();
            AsigurareDBContext dbAsig = new AsigurareDBContext();
            if (ModelState.IsValid)
            {
                string xp = asigurare.Proprietar;
                string xa = asigurare.NrInmatriculare;
                

                var proprietari = from m in dbp.Proprietari
                                 select m;

                var autovehicule = from m in dba.Autovehicule
                                   select m;

                var asigurari = from m in dbAsig.Asigurari
                                select m;


                proprietari = proprietari.Where(s => s.Cnp.Contains(xp));
                autovehicule = autovehicule.Where(s => s.NrInmatriculare.Contains(xa));
               // var asigurari1 = asigurari.Where(s => s.Proprietar.Contains(xp));
                var asigurari2 = asigurari.Where(s => s.NrInmatriculare.Contains(xa));

                int okProprietar = proprietari.Count();
                int okAutovehicul = autovehicule.Count();
               // int okAsigProprietar = asigurari1.Count();
                int okAsigAutovehicul = asigurari2.Count();

              

                if(okProprietar!=0 && okAutovehicul!=0 && okAsigAutovehicul==0)
                {
                db.Asigurari.Add(asigurare);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
            }

            return View(asigurare);
        }

        // GET: Asigurare/Edit/5
        [Authorize(Roles = "User")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asigurare asigurare = db.Asigurari.Find(id);
            if (asigurare == null)
            {
                return HttpNotFound();
            }
            return View(asigurare);
        }

        // POST: Asigurare/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NrInmatriculare,Proprietar,DataValabilitate,Durata")] Asigurare asigurare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asigurare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asigurare);
        }

        // GET: Asigurare/Delete/5
        [Authorize(Roles = "User")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asigurare asigurare = db.Asigurari.Find(id);
            if (asigurare == null)
            {
                return HttpNotFound();
            }
            return View(asigurare);
        }

        // POST: Asigurare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Asigurare asigurare = db.Asigurari.Find(id);
            db.Asigurari.Remove(asigurare);
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
