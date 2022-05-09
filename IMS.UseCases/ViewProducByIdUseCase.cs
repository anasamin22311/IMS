using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases
{
    public class ViewProducByIdUseCase : IViewProducByIdUseCase
    {
        private readonly IProductRepository productRepository;

        public ViewProducByIdUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<Product> ExcuteAsync(int productId)
        {
            return await this.productRepository.GetProductByIdAsync(productId);
        }
    }
}
