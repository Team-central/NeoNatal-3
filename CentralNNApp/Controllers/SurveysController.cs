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
    public class SurveysController : Controller
    {
        private CentralNNAppContext db = new CentralNNAppContext();

        // GET: Surveys
        public ActionResult Index()
        {
            var surveys = db.Surveys.Include(s => s.Mother);
            return View(surveys.ToList());
        }

        // GET: Surveys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // GET: Surveys/Create
        public ActionResult Create()
        {
            ViewBag.MotherID = new SelectList(db.Mothers, "ID", "FirstName");
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CreatedAt,MotherID,Ward,Race,Premature,OBGYN,Age,StressLevel,Smoker,FamilySmoke,Alcohol,FamilyAlcohol,Drug,FamilyDrugs,ChronicIllness,Diet,GovAssit,Income,Education,SafeHome,SafeNeighborhood,Transportation,HomeInternet,MobileInternet,RiskScore")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                // ENTER RISK SCORE CODE HERE!!!
                double risk_Score = 0;

                //QUESTION 1 - Ward
                double ward = Convert.ToInt32(survey.Ward);
                { 
                if (ward == 1) {
                    risk_Score += 53;
                }
                else if (ward == 2) {
                    risk_Score += 17;
                }
                else if (ward == 3) {
                    risk_Score += 18;
                }
                else if (ward == 4) {
                    risk_Score += 16;
                }
                else if (ward == 5) {
                    risk_Score += 37;
                }
                else if (ward == 6) {
                    risk_Score += 15;
                }
                else if (ward == 7) {
                    risk_Score += 19;
                }
                else if (ward == 8)
                {
                    risk_Score += 15;
                }
                else if (ward == 9)
                {
                    risk_Score += 33;
                }
                else if (ward == 10)
                {
                    risk_Score += 32;
                }
                else if (ward == 11)
                {
                    risk_Score += 20;
                }
                else if (ward == 12)
                {
                    risk_Score += 21;
                }
                else if (ward == 13)
                {
                    risk_Score += 16;
                }
                else if (ward == 14)
                {
                    risk_Score += 21;
                }
                else if (ward == 15)
                {
                    risk_Score += 38;
                }
                else if (ward == 16)
                {
                    risk_Score += 31;
                }
                else if (ward == 17)
                {
                    risk_Score += 10;
                }

                //QUESTION 2 - RACE
                int race = Convert.ToInt32(survey.Race);
    
                if (race == 1)
                {
                    risk_Score += 2;
                }
                else
                {
                    risk_Score += 0;
                }
                    
                // QUESTION 3 - PREMATURE BIRTH
                int prem_birth = Convert.ToInt32(survey.Premature);

                if (prem_birth == 1)
                {
                    risk_Score += 5;
                }
                else
                {
                    risk_Score += 0;
                }

                // QUESTION 4 - OBGYN CARE
                int obgyn_care = Convert.ToInt32(survey.OBGYN);

                if (obgyn_care == 2)
                {
                    risk_Score += 5;
                }
                else
                {
                    risk_Score += 0;
                }

                // QUESTION 5 - AGE
                int age = Convert.ToInt32(survey.Age);
                if (age == 1)
                {
                    risk_Score += 4;
                }
                else if (age == 2)
                {
                    risk_Score += 2;
                }
                else if (age == 4)
                {
                    risk_Score += 3;
                }
                else
                {
                    risk_Score += 0;
                }

                // QUESTION 6 - stress level
                int stressLevel = Convert.ToInt32(survey.StressLevel);
                if (stressLevel == 1)
                {
                    risk_Score += 2;
                }
                else if (stressLevel == 2)
                {
                    risk_Score += 1;
                }
                else
                {
                    risk_Score += 0;
                }
                // QUESTION 7 - self smoke 
                int smoker = Convert.ToInt32(survey.Smoker);
                if (smoker == 1)
                {
                    risk_Score += 4;
                }
                else if (smoker == 2)
                {
                    risk_Score += 0;
                }
                else if (smoker == 3)
                {
                    risk_Score += 0;
                }
                //QUESTION 8 - family smoke
                int familySmoke = Convert.ToInt32(survey.FamilySmoke);
                if (familySmoke == 1)
                {
                    risk_Score += 2;
                }
                else if (familySmoke == 2)
                {
                    risk_Score += 0;
                }

                //QUESTION 9 - self alcohol
                int alcohol = Convert.ToInt32(survey.Alcohol);
                if (alcohol == 1)
                {
                    risk_Score += 4;
                }
                else if (alcohol == 2)
                {
                    risk_Score += 0;
                }
                else
                {
                    risk_Score += 0;
                }

                //QUESTION 10 - family alcohol
                int familyalcohol = Convert.ToInt32(survey.FamilyAlcohol);
                if (familyalcohol == 1)
                {
                    risk_Score += 2;
                }
                else if (familyalcohol == 2)
                {
                    risk_Score += 0;
                }

                //QUESTION 11 - slef drug use 
                int drugUse = Convert.ToInt32(survey.Drug);
                if (drugUse == 1)
                {
                    risk_Score += 4;
                }
                else if (drugUse == 2)
                {
                    risk_Score += 0;
                }
                else
                {
                    risk_Score += 0;
                }

                //QUESTION 12 - family drug use
                int familyDrugs = Convert.ToInt32(survey.FamilyDrugs);
                if (familyDrugs == 1)
                {
                    risk_Score += 2;
                }
                else if (familyDrugs == 2)
                {
                    risk_Score += 0;
                }
                else
                {
                    risk_Score += 0;
                }

                // QUESTION 13 - DIET
                int diet = Convert.ToInt32(survey.DietBoolean);

                if (diet == 2)
                {
                    risk_Score += 0.5;
                }
                else if (diet == 3)
                {
                    risk_Score += 1;
                }
                else
                {
                    risk_Score += 0;
                }

                // QUESTION 14 - CHRONIC ILLNESS
                int illness = Convert.ToInt32(survey.ChronicIllness);
                   
                if (illness == 1)
                {
                    risk_Score += 3;
                }
                else
                {
                    risk_Score += 0;
                }

                // QUESTION 15 - INCOME
                int income = Convert.ToInt32(survey.Income);

                if (income == 1)
                {
                    risk_Score += 4;
                }
                else
                {
                    risk_Score += 0;
                }

                // QUESTION 16 - EDUCATION
                int education = Convert.ToInt32(survey.Education);
                if (education == 1)
                {
                    risk_Score += 2;
                }
                else if (education == 2)
                {
                    risk_Score += 1;
                }
                else
                {
                    risk_Score += 0;
                }    
                //calculate risk score
                survey.RiskScore = risk_Score;

                db.Surveys.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
                ViewBag.MotherID = new SelectList(db.Mothers, "ID", "FirstName", survey.MotherID);
                return View(survey);
        }

        // GET: Surveys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            ViewBag.MotherID = new SelectList(db.Mothers, "ID", "FirstName", survey.MotherID);
            return View(survey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CreatedAt,MotherID,Ward,Race,Premature,OBGYN,Age,StressLevel,Smoker,FamilySmoke,Alcohol,FamilyAlcohol,Drug,FamilyDrugs,ChronicIllness,Diet,GovAssit,Income,Education,SafeHome,SafeNeighborhood,Transportation,HomeInternet,MobileInternet")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MotherID = new SelectList(db.Mothers, "ID", "FirstName", survey.MotherID);
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey survey = db.Surveys.Find(id);
            db.Surveys.Remove(survey);
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
