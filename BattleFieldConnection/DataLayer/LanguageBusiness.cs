using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BattleFieldConnection.Models;

namespace BattleFieldConnection.DataLayer
{
    public class LanguageBusiness
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Language> Getdata()
        {
            return db.Languages.ToList();
        }

        public List<Language> GetAll()
        {
            return Getdata().Select(x => new Language
            {
                LanguageID = x.LanguageID,
                LanguageName = x.LanguageName,
                Proficiency = x.Proficiency,
                username = x.username
            }).ToList();
        }
    }
}