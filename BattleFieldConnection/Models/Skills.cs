using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BattleFieldConnection.Models
{
    public class Skills
    {
        [Key]
        public int SkillID { get; set; }
        public string SkillName { get; set; }
        public string username { get; set; }
    }
}