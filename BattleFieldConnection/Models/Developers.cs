using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BattleFieldConnection.Models
{
    public class Developers
    {
        [Key]
        public int DevId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Headline { get; set; }
        public string CurrentPositon { get; set; }
        public string Education { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string industry { get; set; }
        public string Summary { get; set; }
        public byte[] Image { get; set; }
        public string ImageType { get; set; }
    }
}