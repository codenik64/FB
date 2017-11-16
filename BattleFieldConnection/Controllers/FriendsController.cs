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
    public class FriendsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Friends
        public ActionResult Index()
        {
            var friends = db.Friends.Include(f => f.Developers);
          
            var developer = FriendBusiness.GetFriends(this.HttpContext);
            var model = new FriendBusiness
            {
                FriendList = developer.GetDevelopers(),
            };

            return View(model);
        }

        public ActionResult AddFriends(int id)
        {
            var addedFriend = db.Developers.FirstOrDefault(x => x.DevId == id);
            var developer = FriendBusiness.GetFriends(this.HttpContext);
            developer.AddFriend(addedFriend);
            return RedirectToAction("Index");

        }

        public ActionResult FriendList()
        {
            var f = FriendBusiness.GetFriends(this.HttpContext);
            ViewData["FriendCount"] = f.GetFriendcount();
            return PartialView("FriendList");
        }


        // GET: Friends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friends friends = db.Friends.Find(id);
            if (friends == null)
            {
                return HttpNotFound();
            }
            return View(friends);
        }

        // GET: Friends/Create
        public ActionResult Create()
        {
            ViewBag.DevId = new SelectList(db.Developers, "DevId", "Name");
            return View();
        }

        // POST: Friends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FriendID,FriendList,DevId,Count")] Friends friends)
        {
            if (ModelState.IsValid)
            {
                db.Friends.Add(friends);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DevId = new SelectList(db.Developers, "DevId", "Name", friends.DevId);
            return View(friends);
        }

        // GET: Friends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friends friends = db.Friends.Find(id);
            if (friends == null)
            {
                return HttpNotFound();
            }
            ViewBag.DevId = new SelectList(db.Developers, "DevId", "Name", friends.DevId);
            return View(friends);
        }

        // POST: Friends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FriendID,FriendList,DevId,Count")] Friends friends)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friends).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DevId = new SelectList(db.Developers, "DevId", "Name", friends.DevId);
            return View(friends);
        }

        // GET: Friends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friends friends = db.Friends.Find(id);
            if (friends == null)
            {
                return HttpNotFound();
            }
            return View(friends);
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Friends friends = db.Friends.Find(id);
            db.Friends.Remove(friends);
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
