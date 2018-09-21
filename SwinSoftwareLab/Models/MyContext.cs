using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SwinSoftwareLab.Models
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=MyDBConnectionString") { }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}