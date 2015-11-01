using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using MightBeFinal.Models;

namespace MightBeFinal.Models
{
    public class Teacher
    {
        public Teacher()
        {
            TeacherSignUpDate = DateTime.Now;
        }

        [Key]
        [Display(Name = "Number")]
        public int TeacherID { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string TeacherName { get; set; }

        [Display(Name = "Education")]
        [StringLength(50, MinimumLength = 2)]
        public string TeacherEducation { get; set; }

        [Display(Name = "Joined us on")]
        public DateTime TeacherSignUpDate { get; set; }

        [Display(Name = "About")]
        [StringLength(1000)]
        public string TeacherAbout { set; get; }

        [Display(Name = "CoursePicture")]
        public string TeacherPixUrl { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}