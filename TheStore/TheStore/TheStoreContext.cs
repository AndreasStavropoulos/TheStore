﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TheStore.Models;
using Xamarin.Essentials;

namespace TheStore
{
    public class TheStoreContext: DbContext
    {
        public DbSet<Jacket> jackets { get; set; }

        public TheStoreContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "TheShop.sqlite");
            optionsBuilder.UseSqlite($"FileName = {dbPath}");
        }
    }
}