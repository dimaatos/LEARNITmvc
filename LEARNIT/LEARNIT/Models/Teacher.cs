using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LEARNIT.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LEARNIT.Models
{
    public class Teacher
    {
        [Display(Name = "Number")]
        public int TeacherID { get; set; }

        [StringLength(100)]
        [Display(Name = "Teacher")]
        public string TeacherName { get; set; }

        [StringLength(200)]
        [Display(Name = "Graduated")]
        public string Education { get; set; }

        [StringLength(1000)]
        [Display(Name = "About")]
        public string TeacherAbout { get; set; }

        public int PhotoId { get; set; }

        public virtual Photo Photo { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}