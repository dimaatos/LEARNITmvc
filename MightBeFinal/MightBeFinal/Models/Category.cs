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
    public class Category
    {
        [Key]
        [Display(Name = "Number")]
        public int CategoryID { get; set; }

        [Display(Name = "Category")]
        [Required]
        [StringLength(50, ErrorMessage = "Category name cannot be longer than 50 characters.")]
        public string CategoryName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }


    }
}