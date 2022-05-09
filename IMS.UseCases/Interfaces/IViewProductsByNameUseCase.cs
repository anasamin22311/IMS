using IMS.CoreBusiness;

namespace IMS.UseCases
{
    public interface IViewProductsByNameUseCase
    {
        Task<List<Product>> ExcuteAsync(string name = "");
    }
}