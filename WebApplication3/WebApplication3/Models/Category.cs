using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Display(Name = "Category Name")]
        [StringLength(200)]
        public string CategoryName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}