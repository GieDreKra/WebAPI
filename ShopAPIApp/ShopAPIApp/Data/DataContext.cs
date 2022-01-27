using Microsoft.EntityFrameworkCore;
using ShopAPIApp.Models;

namespace ShopAPIApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopItem> Items { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}
