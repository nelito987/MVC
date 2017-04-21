using System.Collections.Generic;
using WheelsShop.Models.BindingModels;
using WheelsShop.Models.ViewModels;

namespace WheelsShop.Services.Contracts
{
    public interface IWheelsService
    {        
        IEnumerable<WheelViewModel> GetAllWheels();
        SearchWheelViewModel LoadDataToViewBag(IEnumerable<WheelViewModel> wheels);
        IEnumerable<WheelViewModel> GetSearchWheelInfo(SearchWheelBindingModel model);
    }
}
