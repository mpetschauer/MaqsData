using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace MaqsData.Contexts
{
    public class DocumentContext : DbContext
    {
        public DocumentContext(DbContextOptions<DocumentContext> options)
            : base(options)
        {


        }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Total> Totals { get; set; }
        public DbSet<Inventory> Inventorys { get; set;}
        public DbSet<InventoryEntry> InventoryEntries { get; set; } 


    }
}
