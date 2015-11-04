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
    public class Subscription
    {
        public int SubscriptionID { get; set; }
        public int CourseID { get; set; }
        public int SubscriberID { get; set; }

        public virtual Course Course { get; set; }
        public virtual Subscriber Subscribers { get; set; }
    }
}