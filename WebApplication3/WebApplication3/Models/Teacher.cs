using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Teacher
    {
        [Display(Name = "Number")]
        public int TeacherID { get; set; }

        [StringLength(100)]
        [Display(Name = "Teacher")]
        public string UserName { get; set; }

        [StringLength(200)]
        [Display(Name = "Graduated")]
        public string Education { get; set; }

        [StringLength(1000)]
        [Display(Name = "About")]
        public string TeacherAbout { get; set; }

        [StringLength(400)]
        [Display(Name = "Photo")]
        public string TeacherPictureURL { get; set; }


        public virtual ICollection<Course> Courses { get; set; }
    }
}