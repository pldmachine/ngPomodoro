using Data.Domain;
using Microsoft.EntityFrameworkCore;
using ngP.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public  class EFContext: DbContext
    {
        public EFContext(DbContextOptions<EFContext> options): base(options)
        {
        }

        public  DbSet<Item> Items { get; set; }
        public DbSet<ChildItem> ChildItems { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<ChildItem>().ToTable("ChildItem");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<TimeLog>().ToTable("TimeLog");
        }

    }
}
