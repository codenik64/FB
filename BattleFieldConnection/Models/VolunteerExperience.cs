using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BattleFieldConnection.Models
{
    public class VolunteerExperience
    {
        [Key]
        public int Veid { get; set; }
        public string Organization { get; set; }
        public string username { get; set; }
        public string Role { get; set; }
        public string Cause { get; set; }
        public DateTime To { get; set; }
        public DateTime From { get; set; }
        public bool IsWorking { get; set; }
        public string Description { get; set; }
    }
}