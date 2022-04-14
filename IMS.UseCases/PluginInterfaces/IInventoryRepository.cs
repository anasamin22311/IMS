using IMS.CoreBusiness;

namespace IMS.UseCases.pluginInterfaces
{
    public interface IInventoryRepository
    {
        Task<Inventory?>GetInventoriesByIdAsync(int inventoryid);
        Task UpdateInventoryAsync (Inventory inventory);
        Task AddInventoryAsync(Inventory inventory);
        Task<IEnumerable<Inventory>>GetInventoriesByName(string name);
    }
}