using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMPSW.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HMPSW.DAL
{
    public class HMContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Community> Community { get; set; }
        public DbSet<Follow> Follow { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Post> Post { get; set; }

        public HMContext() : base("HMContext")
{
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}