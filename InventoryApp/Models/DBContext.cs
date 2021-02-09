using System;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options): base(options)
        {

        }

        public DBContext(){ }
        public DbSet<Store> stores { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<catergory> catergories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<StoreProducts> storeProducts { get; set; }
    }
}
