using System;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Models
{
    public class DBContext : DbContext
    {

        public DBContext(){ }
        public DbSet<Store> stores { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<catergory> catergories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<StoreProducts> storeProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=ziggy.db.elephantsql.com;Database=ddkntivy;Username=ddkntivy;Password=Vj_dJOautdsYm4cvwI36cL1fPbMehqIQ");
    }
}
