using IMS.CoreBusiness;

namespace IMS.UseCases.pluginInterfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>>GetInventoriesByName(string name);
    }
}