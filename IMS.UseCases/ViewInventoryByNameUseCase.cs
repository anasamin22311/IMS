using IMS.CoreBusiness;
using IMS.UseCases.pluginInterfaces;

namespace IMS.UseCases
{
    public class ViewInventoryByNameUseCase : IViewInventoryByNameUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventoryByNameUseCase(IInventoryRepository inventoryRepository)

        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task<IEnumerable<Inventory>> ExcuteAsync(string name)
        {
            return await this.inventoryRepository.GetInventoriesByName(name);
        }

    }
}