using IMS.CoreBusiness;

namespace IMS.UseCases
{
    public interface IEditInventoriesUseCase
    {
        Task ExcuteAsync(Inventory inventory);
    }
}