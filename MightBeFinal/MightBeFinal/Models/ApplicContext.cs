using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using MightBeFinal.Models;

namespace MightBeFinal.Models
{
    public class ApplicContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

    }
}