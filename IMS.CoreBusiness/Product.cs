using IMS.CoreBusiness.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Quanity must be equal or greater than 0")]
        public int Quantity { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price must be equal or greater than 0")]
        [Product_EnsurePricesIsGreaterThanInventoriesPrice]
        public double Price { get; set; }
        public List<ProductInventory>? productInventories { get; set; }
        public double TotalInventoryCost()
        {
            return this.productInventories.Sum(x => x.Inventory?.Price * x.InventoryQuantity ?? 0);

        }
        public bool validatePricing()
        {
            if (productInventories == null || productInventories.Count <= 0) return true;
            if (this.TotalInventoryCost() > Price) return false;
            return true;
        }

    }
}
