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
    public class Category
    {
        public int CategoryID { get; set; }

        [Display(Name = "Category Name")]
        [StringLength(200)]
        public string CategoryName { get; set; }

        public int FieldId { get; set; }

        public virtual Field Field { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}