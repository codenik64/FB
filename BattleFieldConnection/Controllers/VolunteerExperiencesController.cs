using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BattleFieldConnection.Models;
using BattleFieldConnection.DataLayer;

namespace BattleFieldConnection.Controllers
{
    public class VolunteerExperiencesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        VolunteerBusiness vb = new VolunteerBusiness();

        // GET: VolunteerExperiences
        public ActionResult Index()
        {
            return View(db.VolunteerExperiences.ToList());
        }

        public ActionResult VolunteerInfo()
        {
            var a = vb.GetAll().Where(x => x.username == User.Identity.Name).ToList();
            return View(a);
        }
        // GET: VolunteerExperiences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolunteerExperience volunteerExperience = db.VolunteerExperiences.Find(id);
            if (volunteerExperience == null)
            {
                return HttpNotFound();
            }
            return View(volunteerExperience);
        }

        // GET: VolunteerExperiences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VolunteerExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Veid,Organization,username,Role,Cause,To,From,IsWorking,Description")] VolunteerExperience volunteerExperience)
        {
            if (ModelState.IsValid)
            {
                volunteerExperience.username = User.Identity.Name;
                volunteerExperience.To = DateTime.Now.AddDays(5);
                volunteerExperience.From = DateTime.Now;
                db.VolunteerExperiences.Add(volunteerExperience);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volunteerExperience);
        }

        // GET: VolunteerExperiences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolunteerExperience volunteerExperience = db.VolunteerExperiences.Find(id);
            if (volunteerExperience == null)
            {
                return HttpNotFound();
            }
            return View(volunteerExperience);
        }

        // POST: VolunteerExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Veid,Organization,username,Role,Cause,To,From,IsWorking,Description")] VolunteerExperience volunteerExperience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteerExperience).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volunteerExperience);
        }

        // GET: VolunteerExperiences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolunteerExperience volunteerExperience = db.VolunteerExperiences.Find(id);
            if (volunteerExperience == null)
            {
                return HttpNotFound();
            }
            return View(volunteerExperience);
        }

        // POST: VolunteerExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VolunteerExperience volunteerExperience = db.VolunteerExperiences.Find(id);
            db.VolunteerExperiences.Remove(volunteerExperience);
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
