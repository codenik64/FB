using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BattleFieldConnection.Models;

namespace BattleFieldConnection.DataLayer
{
    public class SkillsBusiness
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<Skills> GetData()
        {
            return db.Skills.ToList();
        }

        public List<Skills> GetAll()
        {
            return GetData().Select(x => new Skills
            {
                SkillID = x.SkillID,
                SkillName = x.SkillName,
                username = x.username
            }).ToList();
        }
    }
}
