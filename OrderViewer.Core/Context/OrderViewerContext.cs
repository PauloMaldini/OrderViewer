using System;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.Entities;

namespace OrderViewer.Core.Context
{
    public class OrderViewerContext : DbContext
    {
        public OrderViewerContext (DbContextOptions<OrderViewerContext> options)
            : base(options)
        {
        }
        
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            
        }
    }
}