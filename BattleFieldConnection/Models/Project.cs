using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BattleFieldConnection.Models
{
    public class Project
    {
        [Key]
        public int Pid { get; set; }
        public string projectName { get; set; }
        public string username { get; set; }
        public string ProjectUrl { get; set; }
        public DateTime To { get; set; }
        public DateTime From { get; set; }
        public int Eid { get; set; }
        [ForeignKey("Eid")]
        public virtual Experience Experience { get; set; }
        public string Description { get; set; }
    }
}