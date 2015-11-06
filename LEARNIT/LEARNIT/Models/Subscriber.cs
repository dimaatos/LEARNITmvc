﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LEARNIT.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LEARNIT.Models
{
    public class Subscriber
    {
        [Display(Name = "Number")]
        public int SubscriberID { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }

        [StringLength(100)]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [StringLength(200)]
        [Display(Name = "Name of the Course")]
        public string CourseRequest { get; set; }
        
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}