using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMSContext db;

        public ProductRepository(IMSContext db)
        {
            this.db = db;
        }

        public async Task AddProductAsync(Product product)
        {
            if (db.Products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase))) return;
            db.Products.Add(product);
            await db.SaveChangesAsync();
        }

        public Task<Product> GetAllProductByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await db.Products.FindAsync(productId);
        }

        public async Task<List<Product>> GetProductsByNameAsync(string name)
        {
            return await this.db.Products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
           string.IsNullOrWhiteSpace(name)).ToListAsync(); ;
        }
    }
}
