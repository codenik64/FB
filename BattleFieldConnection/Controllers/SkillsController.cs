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
    public class SkillsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        SkillsBusiness sb = new SkillsBusiness();

        // GET: Skills
        public ActionResult Index()
        {
            return View(db.Skills.ToList());
        }

        public ActionResult SkillsInfo()
        {
            var a = sb.GetAll().Where(x => x.username == User.Identity.Name).ToList();
            return View(a);
        }

        // GET: Skills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skills skills = db.Skills.Find(id);
            if (skills == null)
            {
                return HttpNotFound();
            }
            return View(skills);
        }

        // GET: Skills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SkillID,SkillName,username")] Skills skills)
        {
            if (ModelState.IsValid)
            {
                skills.username = User.Identity.Name;
                db.Skills.Add(skills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skills);
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skills skills = db.Skills.Find(id);
            if (skills == null)
            {
                return HttpNotFound();
            }
            return View(skills);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SkillID,SkillName,username")] Skills skills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skills);
        }

        // GET: Skills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skills skills = db.Skills.Find(id);
            if (skills == null)
            {
                return HttpNotFound();
            }
            return View(skills);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skills skills = db.Skills.Find(id);
            db.Skills.Remove(skills);
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
