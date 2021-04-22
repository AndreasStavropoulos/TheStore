using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Shop21.sqlite");
            optionsBuilder.UseSqlite($"FileName = {dbPath}");
        }
    }
}