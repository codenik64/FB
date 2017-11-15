using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BattleFieldConnection.Models;

namespace BattleFieldConnection.Models
{
    public class EducationBusiness
    {

        ApplicationDbContext db = new ApplicationDbContext();
        public List<Education> GetData()
        {
            return db.Educations.ToList();
        }
        public List<Education> GetAll()
        {
            return GetData().Select(x => new Education
            {
                EducationID = x.EducationID,
                username = x.username,
                Qualification = x.Qualification,
                FieldOfStudy = x.FieldOfStudy,
                grade = x.grade,
                Hobbies = x.Hobbies,
                To = x.To,
                From = x.From,
                Description = x.Description


            }).ToList();
        }
    }
}