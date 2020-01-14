using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;
using VRGameDeals.Data.Models;

namespace VRGameDeals.Data.EF
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }


        public DatabaseContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlatformGame>()
                .HasKey(pg => new { pg.GameGuid, pg.PlatformGuid});
            modelBuilder.Entity<PlatformGame>()
                .HasOne(pg => pg.Game)
                .WithMany(g => g.Platforms)
                .HasForeignKey(pg => pg.GameGuid);

            modelBuilder.Entity<PlatformGame>()
                .HasOne(pg => pg.Platform)
                .WithMany(p => p.Games)
                .HasForeignKey(pg => pg.PlatformGuid);

            base.OnModelCreating(modelBuilder);
        }
    }
}

