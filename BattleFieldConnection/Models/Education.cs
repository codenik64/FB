using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BattleFieldConnection.Models
{
    public class Education
    {
        [Key]
        public int EducationID { get; set; }
        public string username { get; set; }
        public string Qualification { get; set; }
        public string FieldOfStudy { get; set; }
        public int grade { get; set; }
        public string Hobbies { get; set; }
        public DateTime To { get; set; }
        public DateTime From { get; set; }
        public string Description { get; set; }
    }
}