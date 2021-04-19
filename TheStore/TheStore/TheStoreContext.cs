using Microsoft.EntityFrameworkCore;
using TheStore.Models;

namespace TheStore
{
    public class TheStoreContext : DbContext
    {
        public DbSet<Jacket> Jackets { get; set; }
        public DbSet<TShirt> Tshirts { get; set; }
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<Jeans> Jeans { get; set; }

        private const string CONNECTION = @"Server=.\SQLEXPRESS;Database=TheStoreDb;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION);
        }
    }
}