using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LEARNIT.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LEARNIT.Models
{
    public class ApContext : DbContext
    {
        public ApContext() : base("ApContext")
        {
        }

        public DbSet<Field> Fields { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }        
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

       
    }
}