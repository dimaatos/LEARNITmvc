using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MVCtest.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            JoindDay = DateTime.Now;
        }

        [Display(Name = "Joined us on")]
        public DateTime JoindDay { get; set; }

        [Display(Name = "Username")]
        public string Name { get; set; }

        [Display(Name = "Your photo")]
        public string ProfilePicUrl { get; set; }

        [Display(Name = "Your location")]
        public string Location { get; set; }

        [Display(Name = "Tell about yourself")]
        public string About { get; set; }

        [Display(Name = "Your courses")]
        public virtual ICollection<CourseModel> Courses { get; set; }

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
              : base("LearnItDBEntities", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}