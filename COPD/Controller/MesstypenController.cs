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
    public class MesstypenController : System.Web.Mvc.Controller
    {
        private COPDEntities db = new COPDEntities();

        // GET: Messtypen
        public ActionResult Index()
        {
            return View(db.Messtypen.ToList());
        }

        // GET: Messtypen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messtypen messtypen = db.Messtypen.Find(id);
            if (messtypen == null)
            {
                return HttpNotFound();
            }
            return View(messtypen);
        }

        // GET: Messtypen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messtypen/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypName,Zeitintervall")] Messtypen messtypen)
        {
            if (ModelState.IsValid)
            {
                db.Messtypen.Add(messtypen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messtypen);
        }

        // GET: Messtypen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messtypen messtypen = db.Messtypen.Find(id);
            if (messtypen == null)
            {
                return HttpNotFound();
            }
            return View(messtypen);
        }

        // POST: Messtypen/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypName,Zeitintervall")] Messtypen messtypen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messtypen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messtypen);
        }

        // GET: Messtypen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messtypen messtypen = db.Messtypen.Find(id);
            if (messtypen == null)
            {
                return HttpNotFound();
            }
            return View(messtypen);
        }

        // POST: Messtypen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Messtypen messtypen = db.Messtypen.Find(id);
            db.Messtypen.Remove(messtypen);
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
