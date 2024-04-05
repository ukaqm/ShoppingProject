using Microsoft.EntityFrameworkCore;

namespace ShoppingProject.Models
{
    public class ShoppingProjectContext : DbContext
    {
        public ShoppingProjectContext (DbContextOptions<ShoppingProjectContext> options) : base(options) { }

        public DbSet<Item>? Items { get; set; }
    }
}
