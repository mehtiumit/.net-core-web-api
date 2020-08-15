using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavAds>().HasKey(fv => new { fv.AddId, fv.UserId });

            modelBuilder.Entity<FavAds>()
           .HasOne<Add>(sc => sc.Add)
           .WithMany(s => s.FavAdss)
           .HasForeignKey(sc => sc.AddId);

            modelBuilder.Entity<FavAds>()
           .HasOne<User>(sc => sc.User)
           .WithMany(s => s.FavAdss)
           .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<AddAndCategory>().HasKey(ac => new { ac.CategoryId, ac.AddId });

            modelBuilder.Entity<AddAndCategory>()
                .HasOne<Add>(ac => ac.Add)
                .WithMany(aac => aac.AddAndCategories)
                .HasForeignKey(ac => ac.AddId);

            modelBuilder.Entity<AddAndCategory>()
                .HasOne<Category>(ac => ac.Category)
                .WithMany(acc => acc.AddAndCategories)
                .HasForeignKey(ac => ac.CategoryId);
        }

        public DbSet<Add> Adds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FavAds> FavAds { get; set; }
        public DbSet<AddAndCategory> AddAndCategories { get; set; }
    }
}
