using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderProcessSystem.Models;

namespace OrderProcessSystem.Data
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext (DbContextOptions<OrderDBContext> options)
            : base(options)
        {
        }

        public DbSet<OrderProcessSystem.Models.Order> Order { get; set; }
        public DbSet<OrderProcessSystem.Models.OrderCategory> OrderCategory { get; set; }
        public DbSet<OrderProcessSystem.Models.OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProcessSystem.Models.OrderCategory>().HasData(
                new OrderCategory
                {
                    CategoryID = 1,
                    CategoryName = "Fruits",
                    Description = "Fresh Fruits"
                },
                new OrderCategory
                {
                    CategoryID = 2,
                    CategoryName = "Vegetables",
                    Description = "Fresh Vegetables"
                },
                new OrderCategory
                {
                    CategoryID = 3,
                    CategoryName = "Flowers",
                    Description = "Fresh Flowers"
                }
                );
            modelBuilder.Entity<OrderProcessSystem.Models.OrderItem>().HasData(
                new OrderItem
                {
                    ItemID = 1,
                    ItemName = "Apple",
                    CategoryID = 1,
                    Description="Fresh Apple",
                    Price=10
                },
                new OrderItem
                {
                    ItemID = 1,
                    ItemName = "Orange",
                    CategoryID = 1,
                    Description = "Fresh Orange",
                    Price = 5
                },
                new OrderItem
                {
                    ItemID = 1,
                    ItemName = "Banana",
                    CategoryID = 1,
                    Description = "Fresh Banana",
                    Price = 3
                },
                new OrderItem
                {
                    ItemID = 1,
                    ItemName = "Tomato",
                    CategoryID = 2,
                    Description = "Fresh Tomato",
                    Price = 10
                },
                new OrderItem
                {
                    ItemID = 1,
                    ItemName = "Potato",
                    CategoryID = 2,
                    Description = "Fresh Potato",
                    Price = 5
                },
                new OrderItem
                {
                    ItemID = 1,
                    ItemName = "Carrot",
                    CategoryID = 2,
                    Description = "Fresh Carrot",
                    Price = 3
                },
                new OrderItem
                {
                    ItemID = 1,
                    ItemName = "Rose",
                    CategoryID = 3,
                    Description = "Fresh Rose",
                    Price = 10
                },
                new OrderItem
                {
                    ItemID = 1,
                    ItemName = "Marigold",
                    CategoryID = 3,
                    Description = "Fresh Marigold",
                    Price = 5
                },
                new OrderItem
                {
                    ItemID = 1,
                    ItemName = "Jasmine",
                    CategoryID = 3,
                    Description = "Fresh Jasmine",
                    Price = 3
                }
                );

        }

    }
}
