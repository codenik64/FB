using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BattleFieldConnection.Models;
namespace BattleFieldConnection.DataLayer
{
    public class ProjectBusiness
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Project> GetData()
        {
            return db.Projects.ToList();

        }


        public List<Project> GetAll()
        {
            return GetData().Select(x => new Project
            {
                Pid = x.Pid,
                projectName = x.projectName,
                username = x.username,
                ProjectUrl = x.ProjectUrl,
                To = x.To,
                From = x.From,
                Eid = x.Eid,
                Description = x.Description
            }).ToList();
        }
    }
}