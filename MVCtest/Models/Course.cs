using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Microsoft.AspNet.Identity;


namespace MVCtest.Models
{

    public class CourseDBContext : DbContext
    {

        public CourseDBContext() :
            base("LearnItDBEntities")
        { }

        public DbSet<Course> Courses { get; set; }

    }


    public class Course
    {

        [Key]
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [Display(Name = "Course")]
        [Required]
        [StringLength(70, MinimumLength = 2)]
        public string CourseName { set; get; }

        [Display(Name = "About this course")]
        [StringLength(1000, MinimumLength = 2)]
        public string CourseAbout { set; get; }

        [Display(Name = "On air since")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Course Picture")]
        public string PhotoPicUrl { get; set; }
        
        public virtual Teacher Teacher { get; set; }

    }

}