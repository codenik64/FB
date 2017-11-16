using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BattleFieldConnection.Models;

namespace BattleFieldConnection.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Experience()
        {
            var s = db.Experiences.ToList();
            return PartialView("_Experience", s);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult UniqueDeveloper()
        {
            Developers d = new Developers();
            var img = db.Images.FirstOrDefault(x => x.username == User.Identity.Name);
            var sde = img.ImageID;
            var developer = db.Developers.FirstOrDefault(x => x.Email == User.Identity.Name);
            var s = developer.Name + " " + " " + developer.Surname;
            var sid = developer.DevId;
            var headline = developer.Headline;
            var sum = developer.Summary;
            ViewBag.FullName = s;
            ViewBag.id = sde;
            ViewBag.h = headline;
            ViewBag.sum = sum;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}