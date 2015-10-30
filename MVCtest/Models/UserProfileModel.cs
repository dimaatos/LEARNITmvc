using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Microsoft.AspNet.Identity;


namespace MVCtest.Models
{

    public class UserProfileDBContext : DbContext
    {
        public DbSet<UserProfileModel> UserProfiles { get; set; }
    }

    public class UserProfileModel 
    {
        public UserProfileModel()
        {
            JoindDay = DateTime.Now;
        }

        [Key]
        public int UserProfileId { get; set; }

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
        
        public string UserId { get; set; }

        [Display(Name = "Your courses")]
        public virtual ICollection<CourseModel> Courses { get; set; }

    }
}