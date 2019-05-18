using DataAccess.Configurations;
using DataAccess.TableClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Context : DbContext
    {
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-O15G4MH\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SportConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentConfiguration());
            modelBuilder.ApplyConfiguration(new CompetitorConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.Entity<Competitor>().HasMany(c => c.HostsEvent)
                .WithOne(e => e.HostCompetitor)
                .HasForeignKey(e => e.id_competitor_host)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Competitor>().HasMany(c => c.GuestsEvent)
                .WithOne(e => e.GuestCompetitor)
                .HasForeignKey(e => e.id_competitor_guest);
        }
    }
}
    