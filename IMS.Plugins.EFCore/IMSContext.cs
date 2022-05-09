using IMS.CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class IMSContext : DbContext
    {
        public IMSContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //buildrelationships
            modelBuilder.Entity<ProductInventory>().HasKey(pi => new { pi.ProductId, pi.InventoryId });
            modelBuilder.Entity<ProductInventory>().HasOne(pi => pi.product).WithMany(p => p.productInventories).HasForeignKey(pi => pi.ProductId);
            modelBuilder.Entity<ProductInventory>().HasOne(pi => pi.Inventory).WithMany(i => i.productInventories).HasForeignKey(pi => pi.InventoryId);
            //seedingData
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { InventoryId = 1, InventoryName = "Engine", Quantity = 1, Price = 1000 },
                new Inventory { InventoryId = 2, InventoryName = "Body", Quantity = 1, Price = 600 },
                new Inventory { InventoryId = 3, InventoryName = "Seats", Quantity = 5, Price = 50 },
                new Inventory { InventoryId = 4, InventoryName = "Wheels", Quantity = 5, Price = 100 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Gas Car", Price = 2000, Quantity = 2 },
                new Product { ProductId = 2, ProductName = "Hydrolic Car", Price = 3000, Quantity = 2 },
                new Product { ProductId = 3, ProductName = "Electric Car", Price = 4000, Quantity = 10 }
               );
            modelBuilder.Entity<ProductInventory>().HasData(
            new ProductInventory { ProductId = 1, InventoryId = 2, InventoryQuantity = 1 },//Engine
            new ProductInventory { ProductId = 1, InventoryId = 4, InventoryQuantity = 1 },//Body
            new ProductInventory { ProductId = 1, InventoryId = 8, InventoryQuantity = 4 },//Wheels
            new ProductInventory { ProductId = 1, InventoryId = 10, InventoryQuantity = 5 }//Seats
            );
            modelBuilder.Entity<ProductInventory>().HasData(
            new ProductInventory { ProductId = 2, InventoryId = 3, InventoryQuantity = 1 },//Engine
            new ProductInventory { ProductId = 2, InventoryId = 5, InventoryQuantity = 1 },//Body
            new ProductInventory { ProductId = 2, InventoryId = 7, InventoryQuantity = 4 },//Wheels
            new ProductInventory { ProductId = 2, InventoryId = 9, InventoryQuantity = 5 },//Seats
            new ProductInventory { ProductId = 2, InventoryId = 11, InventoryQuantity = 1 }//Battry
            );
        }
    }
}
