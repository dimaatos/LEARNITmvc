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
    public class Field
    {
        [Display(Name = "Number")]
        public int FieldID { get; set; }

        [Display(Name = "Field Name")]
        [StringLength(200)]
        public string FieldName { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}