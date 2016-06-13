using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CentralNNApp.Models;

namespace CentralNNApp.Controllers
{
    public class MothersController : Controller
    {
        private CentralNNAppContext db = new CentralNNAppContext();

        // GET: Mothers
        public ActionResult Index()
        {
            return View(db.Mothers.ToList());
        }

        // GET: Mothers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mother mother = db.Mothers.Find(id);
            if (mother == null)
            {
                return HttpNotFound();
            }
            return View(mother);
        }

        // GET: Mothers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mothers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,DOB,Address,Phone,Email,UserID")] Mother mother)
        {
            if (ModelState.IsValid)
            {
                db.Mothers.Add(mother);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mother);
        }

        // GET: Mothers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mother mother = db.Mothers.Find(id);
            if (mother == null)
            {
                return HttpNotFound();
            }
            return View(mother);
        }

        // POST: Mothers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,DOB,Address,Phone,Email,UserID")] Mother mother)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mother).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mother);
        }

        // GET: Mothers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mother mother = db.Mothers.Find(id);
            if (mother == null)
            {
                return HttpNotFound();
            }
            return View(mother);
        }

        // POST: Mothers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mother mother = db.Mothers.Find(id);
            db.Mothers.Remove(mother);
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
