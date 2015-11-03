using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Subscription
    {
        public int SubscriptionID { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }

        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}