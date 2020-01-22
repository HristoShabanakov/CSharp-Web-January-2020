using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Demo.Data
{
    public class DemoDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DemoDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SHABBY\\SQLEXPRESS;Database=DemoDB;Integrated Security=True;Trusted_Connection=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(user => user.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
