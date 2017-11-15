using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleFieldConnection.Models
{
    public class Courses
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string username { get; set; }
        public int Eid { get; set; }
        [ForeignKey("Eid")]
        public virtual Experience Experience { get; set; }
    }
}