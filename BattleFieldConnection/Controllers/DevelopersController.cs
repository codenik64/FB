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
using System.IO;

namespace BattleFieldConnection.Controllers
{
    public class DevelopersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        DeveloperBusiness devb = new DeveloperBusiness();

        // GET: Developers
        public ActionResult Index()
        {
            return View(db.Developers.ToList());
        }

        public ActionResult ProfileInfo()
        {
            var a = devb.GetAll().FirstOrDefault(x => x.Email == User.Identity.Name);
            return View(a);
        }
        //People you may know
        public ActionResult DeveloperProfile()
        {
            
            //Developers d = new Developers();
          
            //var s = db.Developers.Where(x => x.DevId == d.DevId).FirstOrDefault();
            //var img = db.Images.FirstOrDefault(x => x.username == s.Email);
            //var i = img.ImageID;
            //ViewBag.id = i;
            return View(devb.SimlarProfile(User.Identity.Name));
        }


       


        // GET: Developers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developers developers = db.Developers.Find(id);
            if (developers == null)
            {
                return HttpNotFound();
            }
            return View(developers);
        }

        // GET: Developers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Developers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DevId,Name,Surname,Email,Headline,CurrentPositon,Education,Country,ZipCode,City,industry,Summary,Image,ImageType")] Developers developers )
        {
           
            if (ModelState.IsValid)
            {
                db.Developers.Add(developers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(developers);
        }

     
        // GET: Developers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developers developers = db.Developers.Find(id);
            if (developers == null)
            {
                return HttpNotFound();
            }
            return View(developers);
        }

        // POST: Developers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DevId,Name,Surname,Email,Headline,CurrentPositon,Education,Country,ZipCode,City,industry,Summary")] Developers developers)
        { 

            if (ModelState.IsValid)
            {
                db.Entry(developers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(developers);
        }

        // GET: Developers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developers developers = db.Developers.Find(id);
            if (developers == null)
            {
                return HttpNotFound();
            }
            return View(developers);
        }

       
     
        // POST: Developers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Developers developers = db.Developers.Find(id);
            db.Developers.Remove(developers);
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
