using Microsoft.EntityFrameworkCore;
using ShirtAPI.DB.Models;
using ShirtAPI.Models;

namespace ShirtAPI.DB
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Type> Type { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderCloth> OrderCloths { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<ClothSize> ClothSize { get; set; }
    }
}
