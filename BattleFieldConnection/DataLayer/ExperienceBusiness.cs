using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BattleFieldConnection.Models;

namespace BattleFieldConnection.DataLayer
{
    public class ExperienceBusiness
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Experience> Getdata()
        {
            return db.Experiences.ToList();
        }

        public List<Experience> GetAll()
        {
            return Getdata().Select(x => new Experience
            {
                Eid = x.Eid,
                username = x.username,
                Title = x.Title,
                Organization = x.Organization,
                Location = x.Location,
                To = x.To,
                From = x.From,
                IsWorking = x.IsWorking,
                Description = x.Description
            }).ToList();
        }
    }
}