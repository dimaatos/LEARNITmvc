using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MVCtest.Models
{

    public class CourseDataContext : ApplicationDbContext
    {
        public DbSet<CourseModel> Courses { get; set; }
    }


    public class CourseModel
    {
        public int CourseId { get; set; }

        public string CourseName { set; get; }

        public string CourseAbout { set; get; }

        public int CourseCatagoryId { set; get; }

        public DateTime CreatedDate { get; set; }

        public string PhotoPicUrl { get; set; }

    }
}