using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BattleFieldConnection.Models;

namespace BattleFieldConnection.DataLayer
{
    public class CourseBusiness
    {
            ApplicationDbContext db = new ApplicationDbContext();

            public List<Courses> Getdata()
            {
                return db.Courses.ToList();
            }

            public List<Courses> GetAll()
            {
                return Getdata().Select(x => new Courses
                {
                    CourseID = x.CourseID,
                    CourseName = x.CourseName,
                    username = x.username,
                    Eid = x.Eid
                }).ToList();
            }
        }
}