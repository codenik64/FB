using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BattleFieldConnection.Models;

namespace BattleFieldConnection.DataLayer
{
    public partial class FriendBusiness
    {
        public List<Friends> FriendList { get; set; }

        ApplicationDbContext db = new ApplicationDbContext();
        string FriendlistID { get; set; }
        public const string FriendSession = "FriendList";

      
        public string GetMyFriendList(HttpContextBase context)
        {
            if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
            {
                context.Session[FriendSession] = context.User.Identity.Name;
            }
            else
            {
                Guid tempList = Guid.NewGuid();
                // Send tempCartId back to client as a cookie
                context.Session[FriendSession] = tempList.ToString();
            }


            return context.Session[FriendSession].ToString();
        }

        public static FriendBusiness GetFriends(HttpContextBase context)
        {
            var friend = new FriendBusiness();
            friend.FriendlistID = friend.GetMyFriendList(context);
            return friend;

        }

        public static FriendBusiness GetFriends(Controller controller)
        {
            return GetFriends(controller.HttpContext);
        }

        public void AddFriend(Developers developer)
        {
            var foundDeveloper = db.Friends.FirstOrDefault(x => x.FriendList == FriendlistID && x.DevId == developer.DevId);

            if (foundDeveloper == null)
            {
                foundDeveloper = new Friends
                {
                    DevId = developer.DevId,
                    FriendList = FriendlistID,
                    Count = 1,

                };
                db.Friends.Add(foundDeveloper);
            }
            db.SaveChanges();
         
        }

        public int Unfriend( int id)
        {
            var foundDeveloper = db.Friends.FirstOrDefault(x => x.FriendList == FriendlistID && x.FriendID == id);
            int FriendCount = 0;
            if (foundDeveloper != null)
            {
                if (foundDeveloper.Count >= 1)
                {
                    foundDeveloper.Count--;
                    FriendCount = foundDeveloper.Count;
                }
                else
                {
                    db.Friends.Remove(foundDeveloper);
                }
                db.SaveChanges();
            }
            return FriendCount;
        }

        public List<Friends> GetDevelopers()
        {
            return db.Friends.Where(x => x.FriendList == FriendlistID).ToList();
        }

        public int GetFriendcount()
        {
            int? Count = (from dev in db.Friends
                          where dev.FriendList == FriendlistID
                          select (int?)dev.Count).Sum();
            return Count ?? 0;
        }

    }
}