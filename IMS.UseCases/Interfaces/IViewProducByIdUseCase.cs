using IMS.CoreBusiness;

namespace IMS.UseCases
{
    public interface IViewProducByIdUseCase
    {
        Task<Product> ExcuteAsync(int productId);
    }
}