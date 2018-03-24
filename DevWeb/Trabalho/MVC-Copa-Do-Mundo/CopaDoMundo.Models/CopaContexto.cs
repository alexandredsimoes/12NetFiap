using Microsoft.EntityFrameworkCore;
using System;

namespace CopaDoMundo.Models
{
    public class CopaContexto : DbContext
    {
        public DbSet<Time> Times { get; set; }       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlite("Filename=Copa.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Time>()
                .Property(c => c.Nome)
                .HasMaxLength(100);
        }
    }
}
