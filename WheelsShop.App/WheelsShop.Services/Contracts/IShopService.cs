using System.Collections.Generic;
using WheelsShop.Models.ViewModels;

namespace WheelsShop.Services.Contracts
{
    public interface IShopService
    {
        TyreViewModel ViewProduct(int productId);
        void AddToCart(int productId, string userId, int quantity);
        IEnumerable<OrderViewModel> GetOrdersInCart(string userId);
        void ChangeOrderStatusToProcessing(int[] orderIds);
        IEnumerable<OrderViewModel> GetAllOrdersForUser(string userId);
        void RemoveItemFromCart(string userId, int orderId);
        WheelViewModel ViewWheel(int productId);
    }
}
