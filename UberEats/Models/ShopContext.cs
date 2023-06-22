using Microsoft.EntityFrameworkCore;

namespace UberEats.Models
{
    public class UberEatsContext : DbContext
    {
        public UberEatsContext(DbContextOptions<UberEatsContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Partner> Partners { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Restaurant" },
                new Category { CategoryID = 2, Name = "Grocery" },
                new Category { CategoryID = 3, Name = "Alcohol" },
                new Category { CategoryID = 4, Name = "Convenience" },
                new Category { CategoryID = 5, Name = "Flowers" },
                new Category { CategoryID = 6, Name = "Petstore" },
                new Category { CategoryID = 7, Name = "Retail" }
            );

            modelBuilder.Entity<Partner>().HasData(
                new Partner
                {
                    PartnerID = 1, 
                    CategoryID = 2,
                    Email = "iharvd@mail.com",
                    Name = "Indian Harvest",
                    Phone = 0793648292,
                    Address = "Ash Road",
                    //Status = true
                   // BusinessTypeId = 
                },
                new Partner
                {
                    PartnerID = 2,
                    CategoryID = 4,
                    Email = "celicreate@email.com",
                    Name = "Celidan creation",
                    Phone = 0793657592,
                    Address = "Ash Road",
                   // Status = false
                    //BusinessTypeId = (decimal)1199.00
                },
                new Partner
                {
                    PartnerID = 3,
                    CategoryID = 1,
                    Email = "chicks@email.com",
                    Name = "CHicken Inn",
                    Phone = 0795849292,
                    Address = "Spruce Street",
                    //Status = false
                    //BusinessTypeId = (decimal)2517.00
                }
            );
        }
    }
}