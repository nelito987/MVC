using System.Collections.Generic;
using WheelsShop.Models.ViewModels;

namespace WheelsShop.Services.Contracts
{
    public interface IShopService
    {
        TyreViewModel ViewProduct(int productId);
        bool AddToCart(int productId, string userId, int quantity);
        IEnumerable<OrderViewModel> GetOrdersInCart(string userId);
        void ChangeOrderStatusToProcessing(int[] orderIds);
        IEnumerable<OrderViewModel> GetAllOrdersForUser(string userId);
        void RemoveItemFromCart(int orderId);
        WheelViewModel ViewWheel(int productId);
        string GetProductDescriptionById(int id);
    }
}
