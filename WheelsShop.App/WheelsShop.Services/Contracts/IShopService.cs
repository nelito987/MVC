using WheelsShop.Models.ViewModels;

namespace WheelsShop.Services.Contracts
{
    public interface IShopService
    {
        TyreViewModel ViewProduct(int productId);
    }
}
