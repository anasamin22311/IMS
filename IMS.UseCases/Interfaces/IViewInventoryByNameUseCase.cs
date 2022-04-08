using IMS.CoreBusiness;

namespace IMS.UseCases
{
    public interface IViewInventoryByNameUseCase
    {
        Task<IEnumerable<Inventory>> ExcuteAsync(string name);
    }
}