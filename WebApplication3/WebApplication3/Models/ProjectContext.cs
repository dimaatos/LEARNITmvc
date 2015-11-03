using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;
using System.Data.Entity;

namespace WebApplication3.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("ProjectContext")
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}