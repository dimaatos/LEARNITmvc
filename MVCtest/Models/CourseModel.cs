using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace MVCtest.Models
{

    public class CourseDbContext : DbContext
    {
        public DbSet<CourseModel> Courses { get; set; }
    }


    public class CourseModel
    {
        [Key]
        public int CourseId { get; set; }

        public string CourseName { set; get; }

        public string CourseAbout { set; get; }

        public int CourseCatagoryId { set; get; }

        public DateTime CreatedDate { get; set; }

        public string PhotoPicUrl { get; set; }

    }
}