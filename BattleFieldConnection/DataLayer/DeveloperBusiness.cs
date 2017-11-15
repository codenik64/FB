using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BattleFieldConnection.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BattleFieldConnection.DataLayer
{
    public class DeveloperBusiness
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<Developers> Getdata()
        {
            return db.Developers.ToList();
        }

        public List<Developers> GetAll()
        {
            return Getdata().Select(x => new Developers {
                DevId = x.DevId,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Headline = x.Headline,
                CurrentPositon = x.CurrentPositon,
                Education = x.Education,
                Country = x.Country,
                ZipCode = x.ZipCode,
                City = x.City,
                industry = x.industry,
                Summary = x.Summary,
                Image = x.Image,
                ImageType = x.ImageType
            }).ToList();
        }

        public void RegisterDeveloper(RegisterViewModel model)
        {
            Developers d = new Developers();
            d.Name = model.Name;
            d.Surname = model.Surname;
            d.Email = model.Email;
            d.Headline = model.Headline;
            d.CurrentPositon = model.CurrentPositon;
            d.Education = model.Education;
            d.Country = model.Country;
            d.ZipCode = model.ZipCode;
            d.City = model.City;
            d.industry = model.industry;
            d.Summary = model.Summary;
            d.Image = model.Image;
            d.ImageType = model.ImageType;
            db.Developers.Add(d);
            db.SaveChanges();
        }

        public List<Developers> SimlarProfile( string username)
        {
            //Developers d = new Developers();
            var s = HttpContext.Current.User.Identity.Name;
            var foundDeveloper = db.Developers.FirstOrDefault(x => x.Email == username);

            return db.Developers.Where(x => x.City == foundDeveloper.City || x.Education == foundDeveloper.Education || x.CurrentPositon == foundDeveloper.CurrentPositon).ToList();
           
        }
    }
}