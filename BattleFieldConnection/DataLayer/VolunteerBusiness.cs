using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BattleFieldConnection.Models;
namespace BattleFieldConnection.DataLayer
{
    public class VolunteerBusiness
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<VolunteerExperience> Getdata()
        {
            return db.VolunteerExperiences.ToList();
        }

        public List<VolunteerExperience> GetAll()
        {
            return Getdata().Select(x => new VolunteerExperience
            {
                Veid = x.Veid,
                Organization = x.Organization,
                username = x.username,
                Role = x.Role,
                Cause = x.Cause,
                To = x.To,
                From = x.From,
                IsWorking = x.IsWorking,
                Description = x.Description
            }).ToList();
        }
    }
}
