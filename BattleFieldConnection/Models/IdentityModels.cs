using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BattleFieldConnection.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BattleFieldConnection.Models.Developers> Developers { get; set; }
        public System.Data.Entity.DbSet<BattleFieldConnection.Models.Courses> Courses { get; set; }

        public System.Data.Entity.DbSet<BattleFieldConnection.Models.Friends> Friends { get; set; }
        public System.Data.Entity.DbSet<BattleFieldConnection.Models.Experience> Experiences { get; set; }

        public System.Data.Entity.DbSet<BattleFieldConnection.Models.Education> Educations { get; set; }

        public System.Data.Entity.DbSet<BattleFieldConnection.Models.Language> Languages { get; set; }

        public System.Data.Entity.DbSet<BattleFieldConnection.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<BattleFieldConnection.Models.Skills> Skills { get; set; }

        public System.Data.Entity.DbSet<BattleFieldConnection.Models.VolunteerExperience> VolunteerExperiences { get; set; }

        public System.Data.Entity.DbSet<BattleFieldConnection.Models.Images> Images { get; set; }
    }
}