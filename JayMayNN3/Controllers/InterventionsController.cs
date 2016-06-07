using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JayMayNN3.Models;

namespace JayMayNN3.Controllers
{
    public class InterventionsController : Controller
    {
        private JayMayNN3Context db = new JayMayNN3Context();

        // GET: Interventions
        public ActionResult Index()
        {
            var interventions = db.Interventions.Include(i => i.Survey);
            return View(interventions.ToList());
        }

        // GET: Interventions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intervention intervention = db.Interventions.Find(id);
            if (intervention == null)
            {
                return HttpNotFound();
            }
            return View(intervention);
        }

        // GET: Interventions/Create
        public ActionResult Create()
        {
            ViewBag.SurveyID = new SelectList(db.Surveys, "ID", "VisitOBGYN");
            return View();
        }

        // POST: Interventions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SurveyID,Notes_Description")] Intervention intervention)
        {
            if (ModelState.IsValid)
            {
                db.Interventions.Add(intervention);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SurveyID = new SelectList(db.Surveys, "ID", "VisitOBGYN", intervention.SurveyID);
            return View(intervention);
        }

        // GET: Interventions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intervention intervention = db.Interventions.Find(id);
            if (intervention == null)
            {
                return HttpNotFound();
            }
            ViewBag.SurveyID = new SelectList(db.Surveys, "ID", "VisitOBGYN", intervention.SurveyID);
            return View(intervention);
        }

        // POST: Interventions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SurveyID,Notes_Description")] Intervention intervention)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intervention).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SurveyID = new SelectList(db.Surveys, "ID", "VisitOBGYN", intervention.SurveyID);
            return View(intervention);
        }

        // GET: Interventions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intervention intervention = db.Interventions.Find(id);
            if (intervention == null)
            {
                return HttpNotFound();
            }
            return View(intervention);
        }

        // POST: Interventions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Intervention intervention = db.Interventions.Find(id);
            db.Interventions.Remove(intervention);
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
