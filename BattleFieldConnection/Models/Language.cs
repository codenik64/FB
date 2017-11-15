using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BattleFieldConnection.Models
{
    public class Language
    {
        [Key]
        public int LanguageID { get; set; }
        public string LanguageName { get; set; }
        public string username { get; set; }
        public string Proficiency { get; set; }
    }
}