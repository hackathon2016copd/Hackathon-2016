using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace COPD
{
    public class PatientenController : System.Web.Mvc.Controller
    {
        private COPDEntities db = new COPDEntities();

        // GET: Patienten
        public ActionResult Index()
        {
            return View(db.Patienten.ToList());
        }

        // GET: Patienten/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patienten patienten = db.Patienten.Find(id);
            if (patienten == null)
            {
                return HttpNotFound();
            }
            return View(patienten);
        }

        // GET: Patienten/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patienten/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Vorname,Nachname,Geburtsdatum")] Patienten patienten)
        {
            if (ModelState.IsValid)
            {
                db.Patienten.Add(patienten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patienten);
        }

        // GET: Patienten/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patienten patienten = db.Patienten.Find(id);
            if (patienten == null)
            {
                return HttpNotFound();
            }
            return View(patienten);
        }

        // POST: Patienten/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Vorname,Nachname,Geburtsdatum")] Patienten patienten)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patienten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patienten);
        }

        // GET: Patienten/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patienten patienten = db.Patienten.Find(id);
            if (patienten == null)
            {
                return HttpNotFound();
            }
            return View(patienten);
        }

        // POST: Patienten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patienten patienten = db.Patienten.Find(id);
            db.Patienten.Remove(patienten);
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
