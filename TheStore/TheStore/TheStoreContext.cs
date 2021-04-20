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

        public TheStoreContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "TheShop9.sqlite");
            optionsBuilder.UseSqlite($"FileName = {dbPath}");
        }
    }
}