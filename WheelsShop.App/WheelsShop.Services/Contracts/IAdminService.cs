using System.Collections.Generic;
using WheelsShop.Models.BindingModels;
using WheelsShop.Models.ViewModels;

namespace WheelsShop.Services.Contracts
{
    public interface IAdminService
    {
        //TODO: Check if all methods of the services are in the interface
        void AddNewTyre(NewTyreBindingModel tyre);
        void AddNewWheel(NewWheelBindingModel wheel);
        IEnumerable<OrderViewModel> GetAllOrders();
        OrderViewModel GetOrderById(int orderId);
        void ChangeOrderStatus(OrderBindingModel model);
        void DeleteProduct(int id);
        ProductViewModel GetEditedProduct(int id);
        void UpdateProduct(EditProductBindingModel product);
    }
}
