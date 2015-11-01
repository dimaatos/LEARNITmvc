using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using MightBeFinal.Models;
using System.Web.Mvc;

namespace MightBeFinal.Models
{
    public class Course
    {
        public Course()
        {
            CreatedDate = DateTime.Now;
        }

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

        public virtual Category Category { get; set; }

        public virtual Teacher Teacher { get; set; }
       
    }
}