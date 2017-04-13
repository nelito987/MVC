using WheelsShop.Models.BindingModels;

namespace WheelsShop.Services.Contracts
{
    public interface IAdminService
    {
        //TODO: Check if all methods of the services are in the interface
        void AddNewTyre(NewTyreBindingModel tyre);
    }
}
