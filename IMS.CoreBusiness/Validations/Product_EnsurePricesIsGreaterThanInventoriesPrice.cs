using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Validations
{
    internal class Product_EnsurePricesIsGreaterThanInventoriesPrice : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;
            if (product != null)
            {
                if (product.validatePricing())
                    return new ValidationResult($"The product's price is less than the summary of it's inventories price:{product.TotalInventoryCost()}!",
                        new[] { validationContext.MemberName});
            }
            return ValidationResult.Success;
        }
    }
}
