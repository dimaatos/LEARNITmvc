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
    public class Course
    {
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Title")]
        public string CourseName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "On air since")]
        public DateTime StartDate { get; set; }

        [StringLength(1000)]
        [Display(Name = "About")]
        public string CourseAbout { get; set; }

        public int CategoryId { get; set; }

        public int TeacherId { get; set; }

        public int PhotoId { get; set; }

        public virtual Photo Photo { get; set; }
        public virtual Category Category { get; set; }
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}