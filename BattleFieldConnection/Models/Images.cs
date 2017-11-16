using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BattleFieldConnection.Models
{
    public class Images
    {
        [Key]
        public int ImageID { get; set; }
        public byte[] Image { get; set; }
        public string ImageType { get; set; }
        public string username { get; set; }
    }
}