using System.Collections.Generic;
using WheelsShop.Models.ViewModels;

namespace WheelsShop.Services.Contracts
{
    public interface IShopService
    {
        TyreViewModel ViewProduct(int productId);
        void AddToCart(int productId, string userId, int quantity);
        CartViewModel GetOrdersInCart(string userId);
    }
}
