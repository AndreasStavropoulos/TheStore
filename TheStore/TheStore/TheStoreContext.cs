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
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Shop22.sqlite");
            optionsBuilder.UseSqlite($"FileName = {dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //todo replace by seed (.hasdata)
            modelBuilder.Entity<User>().HasData(GetUsers());
        }

        private List<User> GetUsers()
        {
            List<User> users = new List<User>
            {
                new User
            {
                Id = 1,
                Email = "andreas@store.be",
                Name = "Andreas",
                Password = "1234",
                IsAdmin = false
            },

                 new User
            {
                Id = 2,
                Email = "emma@store.be",
                Name = "Emma",
                Password = "12345",
                IsAdmin = false
            },
                      new User
            {
                Id = 3,
                Email = "p",
                Name = "Pieter",
                Password = "p",
                IsAdmin = false
            },
            };
            return users;
        }
    }
}