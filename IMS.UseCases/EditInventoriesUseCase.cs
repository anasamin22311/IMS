using IMS.CoreBusiness;
using IMS.UseCases.pluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases
{
    public class EditInventoriesUseCase : IEditInventoriesUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public EditInventoriesUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task ExcuteAsync(Inventory inventory)
        {
            await this.inventoryRepository.UpdateInventoryAsync(inventory);
        }
    }
}
