using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BattleFieldConnection.Models
{
    public class Friends
    {
        [Key]
        public int FriendID { get; set; }
        public string FriendList { get; set; }
        public int DevId { get; set; }
        public virtual Developers Developers { get; set; }
        public int Count { get; set; }
    }
}