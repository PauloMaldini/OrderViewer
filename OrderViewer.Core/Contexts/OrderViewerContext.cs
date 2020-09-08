using System;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.Entities;
using OrderViewer.Core.Enums;

namespace OrderViewer.Core.Contexts
{
    public class OrderViewerContext : DbContext
    {
        public OrderViewerContext (DbContextOptions<OrderViewerContext> options)
            : base(options)
        {
            
        }
        
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<OrderItem> OrderItems { get; set; }
        
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            #region [ Products ]
            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Name = "Laptop", Description = "", Price = 1300 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 2, Name = "Web camera", Description = "", Price = 53.23m });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 3, Name = "Router", Description = "", Price = 120 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 4, Name = "Commutator", Description = "", Price = 5500 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 5, Name = "Printer", Description = "", Price = 217 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 6, Name = "Display", Description = "", Price = 528 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 7, Name = "Phone", Description = "", Price = 790 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 8, Name = "Headphones", Description = "", Price = 34.77m });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 9, Name = "SSD", Description = "", Price = 115 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 10, Name = "RAM", Description = "", Price = 91 });
            #endregion
            
            #region [ Orders ]
            modelBuilder.Entity<Order>().HasData(new Order { Id = 1, Timestamp = DateTime.Parse("2020-03-15 10:34"), 
                OrderState = OrderState.Completed});
            modelBuilder.Entity<Order>().HasData(new Order { Id = 2, Timestamp = DateTime.Parse("2020-06-24 20:01"), 
                OrderState = OrderState.Completed});
            modelBuilder.Entity<Order>().HasData(new Order { Id = 3, Timestamp = DateTime.Parse("2020-08-27 14:59"), 
                OrderState = OrderState.Completed});
            modelBuilder.Entity<Order>().HasData(new Order { Id = 4, Timestamp = DateTime.Parse("2020-09-07 11:14"), 
                OrderState = OrderState.InProgress});
            modelBuilder.Entity<Order>().HasData(new Order { Id = 5, Timestamp = DateTime.Parse("2020-09-08 21:33"), 
                OrderState = OrderState.InProgress});
            #endregion

            #region [ OrderItems ]
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 1, OrderRefId = 1, ProductRefId = 1, Quantity = 1 });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 2, OrderRefId = 1, ProductRefId = 3, Quantity = 3 });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 3, OrderRefId = 1, ProductRefId = 10, Quantity = 1 });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 4, OrderRefId = 1, ProductRefId = 7, Quantity = 5 });
            
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 5, OrderRefId = 2, ProductRefId = 2, Quantity = 10 });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 6, OrderRefId = 2, ProductRefId = 8, Quantity = 5 });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 7, OrderRefId = 2, ProductRefId = 6, Quantity = 2 });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 8, OrderRefId = 2, ProductRefId = 3, Quantity = 3 });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 9, OrderRefId = 2, ProductRefId = 7, Quantity = 1 });
            
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 10, OrderRefId = 3, ProductRefId = 1, Quantity = 2 });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 11, OrderRefId = 3, ProductRefId = 10, Quantity = 1 });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 12, OrderRefId = 3, ProductRefId = 9, Quantity = 4 });
            
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 13, OrderRefId = 4, ProductRefId = 3, Quantity = 1 });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 14, OrderRefId = 4, ProductRefId = 6, Quantity = 1 });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 15, OrderRefId = 4, ProductRefId = 7, Quantity = 1 });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 16, OrderRefId = 4, ProductRefId = 9, Quantity = 6 });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 17, OrderRefId = 4, ProductRefId = 1, Quantity = 9 });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 18, OrderRefId = 4, ProductRefId = 10, Quantity = 2 });
            
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 19, OrderRefId = 5, ProductRefId = 1, Quantity = 5 });
            #endregion
        }
    }
}