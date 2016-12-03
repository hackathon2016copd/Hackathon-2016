using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COPD;

namespace COPD.Controller
{
    public class MessdatenController : System.Web.Mvc.Controller
    {
        private COPDEntities db = new COPDEntities();

        // GET: Messdaten
        public ActionResult Index()
        {
            var messdaten = db.Messdaten.Include(m => m.Patienten).Include(m => m.Messtypen);
            return View(messdaten.ToList());
        }

        // GET: Messdaten/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messdaten messdaten = db.Messdaten.Find(id);
            if (messdaten == null)
            {
                return HttpNotFound();
            }
            return View(messdaten);
        }

        // GET: Messdaten/Create
        public ActionResult Create()
        {
            ViewBag.FK_PatientID = new SelectList(db.Patienten, "Id", "Vorname");
            ViewBag.FK_MesstypID = new SelectList(db.Messtypen, "Id", "TypName");
            return View();
        }

        // POST: Messdaten/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FK_MesstypID,FK_PatientID")] Messdaten messdaten)
        {
            if (ModelState.IsValid)
            {
                db.Messdaten.Add(messdaten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_PatientID = new SelectList(db.Patienten, "Id", "Vorname", messdaten.FK_PatientID);
            ViewBag.FK_MesstypID = new SelectList(db.Messtypen, "Id", "TypName", messdaten.FK_MesstypID);
            return View(messdaten);
        }

        // GET: Messdaten/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messdaten messdaten = db.Messdaten.Find(id);
            if (messdaten == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_PatientID = new SelectList(db.Patienten, "Id", "Vorname", messdaten.FK_PatientID);
            ViewBag.FK_MesstypID = new SelectList(db.Messtypen, "Id", "TypName", messdaten.FK_MesstypID);
            return View(messdaten);
        }

        // POST: Messdaten/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FK_MesstypID,FK_PatientID")] Messdaten messdaten)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messdaten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_PatientID = new SelectList(db.Patienten, "Id", "Vorname", messdaten.FK_PatientID);
            ViewBag.FK_MesstypID = new SelectList(db.Messtypen, "Id", "TypName", messdaten.FK_MesstypID);
            return View(messdaten);
        }

        // GET: Messdaten/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messdaten messdaten = db.Messdaten.Find(id);
            if (messdaten == null)
            {
                return HttpNotFound();
            }
            return View(messdaten);
        }

        // POST: Messdaten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Messdaten messdaten = db.Messdaten.Find(id);
            db.Messdaten.Remove(messdaten);
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
