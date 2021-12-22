using InventorySklad.Data.Item;
using InventorySklad.Data.Sklad;
using Microsoft.EntityFrameworkCore;

namespace InventorySklad.Data
{
    public class InventorySkladContext : DbContext
    {
        public DbSet<SkladDto> Sklads { get; set; }
        public DbSet<ItemDto> Items { get; set; }
        
        public InventorySkladContext(DbContextOptions<InventorySkladContext> options) : base(options)
        {
        }
    }
}