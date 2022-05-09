using IMS.CoreBusiness;

namespace IMS.UseCases
{
    public interface IAddProductUseCase
    {
        Task ExcuteAsync(Product product);
    }
}