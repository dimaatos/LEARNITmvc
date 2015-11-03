using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class User
    {
        [Display(Name = "Number")]
        public int UserID { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }

        [StringLength(100)]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}