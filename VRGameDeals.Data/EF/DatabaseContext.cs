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
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }

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
                .HasKey(pg => pg.Guid);

            modelBuilder.Entity<PlatformGame>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PlatformGame>()
                .HasOne(pg => pg.Game)
                .WithMany(g => g.Platforms)
                .HasForeignKey(pg => pg.GameId);

            modelBuilder.Entity<PlatformGame>()
                .HasOne(pg => pg.Platform)
                .WithMany(p => p.Games)
                .HasForeignKey(pg => pg.PlatformId);

            modelBuilder.Entity<Game>()
                .HasKey(g => g.Guid);


            modelBuilder.Entity<Platform>()
                .HasKey(g => g.Guid);

            modelBuilder.Entity<Discount>()
                .HasKey(d => d.Guid);
            modelBuilder.Entity<Discount>()
                .HasOne(d => d.PlatformGame)
                .WithMany(pg => pg.Discounts)
                .HasForeignKey(pg => pg.PlatformGameId);
            modelBuilder.Entity<Discount>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");


            Game game = new Game(Guid.Parse("26f2a34c-7f9f-40e6-aeca-6a875ace5be9"), "Pavlov", "FPS Shooter");
            Platform platform = new Platform(Guid.Parse("c4149c8f-b816-4c75-ae8d-94c9b7d18c9b"), "Oculus Quest", "Mobile");
            PlatformGame platformGame = new PlatformGame(game.Guid, platform.Guid, new DateTime(2019, 09, 15), 99);

            modelBuilder.Entity<Game>()
                .HasData(game);
            modelBuilder.Entity<Platform>()
                .HasData(platform);
            modelBuilder.Entity<PlatformGame>()
                .HasData(platformGame);


            base.OnModelCreating(modelBuilder);
        }
    }
}
