using System.Data.Common;
using E_Commerce_System_API_Final.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_System_API_Final.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<User> users { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> ordersItems { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasIndex(e => e.Email)
                .IsUnique();


            modelBuilder.Entity<Category>()
                .HasIndex(n => n.Name)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasMany(p => p.products)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<User>()
                .HasMany(p => p.orders)
                .WithOne(c => c.user)
                .HasForeignKey(c => c.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasMany(p => p.orderItems)
                .WithOne(c => c.Order)
                .HasForeignKey(c => c.OrderID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Product>()
                .HasMany(p => p.orderItems)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<User>()
                .HasData(

                    new User { id = 1, FullName = "Mohamed Hassan", Email = "mohamedhassan@gmail.com", PasswordHash = "12345678A", Role = "Customer" },
                    new User { id = 2, FullName = "Store Admin", Email = "admin@example.com", PasswordHash = "123456Adm", Role = "Admin" }

                );


            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { Id = 1 , Name = "Electronics"  , Description = "Electronic devices and accessories" },
                    new Category { Id = 2 , Name = "Books"  , Description = "Programming and technical books" }
                );

            modelBuilder.Entity<Product>()
                .HasData(

                    new Product { id = 1, Name = "Wireless Mouse", Price = 450m, StockQantity = 25, Description = "Goooooood", CategoryID = 1 },
                    new Product { id = 2, Name = "C++ Fundamentals", Price = 350m, StockQantity = 30, Description = "From Hero To Zero", CategoryID = 2 }

                );

            modelBuilder.Entity<Order>()
                .HasData(

                    new Order { id = 1, OrderDate = new DateTime(2026 - 10 - 01), Status = "Completed", TotalAmount = 800.00m, UserID = 1 },
                    new Order { id = 2, OrderDate = new DateTime(2026 - 10 - 10), Status = "Pending", TotalAmount = 1200.00m, UserID = 1 }

                );

            modelBuilder.Entity<OrderItem>()
                .HasData(

                    new OrderItem { Id = 1, Quantity = 1, UnitPrice = 450m, OrderID = 1, ProductID = 1 },
                    new OrderItem { Id = 2, Quantity = 1, UnitPrice = 350m, OrderID = 2, ProductID = 2 }
                );





            base.OnModelCreating(modelBuilder);
        }

    }
}
