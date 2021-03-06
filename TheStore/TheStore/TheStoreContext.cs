using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using TheStore.Models;
using Xamarin.Essentials;

namespace TheStore
{
    public class TheStoreContext : DbContext
    {
        public DbSet<Jacket> Jackets { get; set; }
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<TShirt> TShirts { get; set; }
        public DbSet<Jeans> Jeans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public TheStoreContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "ShopDataBase.sqlite");
            optionsBuilder.UseSqlite($"FileName = {dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //todo replace by seed (.hasdata)
            //modelBuilder.Entity<User>().HasData(GetUsers());
        }
        
    }
}