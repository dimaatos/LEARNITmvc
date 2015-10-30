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

        public DateTime JoindDay { get; set; }

        public string Name { get; set; }

        public string ProfilePicUrl { get; set; }

        public string Location { get; set; }

        public string About { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<CourseModel> Courses { get; set; }

    }
}