using System.Collections.Generic;
using WheelsShop.Models.BindingModels;
using WheelsShop.Models.EntityModels;
using WheelsShop.Models.ViewModels;

namespace WheelsShop.Services.Contracts
{
    public interface IWheelsService
    {
        //IEnumerable<WheelViewModel> GetAllTyresVM();
        //IEnumerable<Wheel> GetAllTyres();
        //SearchWheelViewModel LoadDataToViewBag(IEnumerable<Wheel> tyres);
        //TyresViewModel GetSearchTyreInfo(SearchTyreBindingModel model);
        IEnumerable<WheelViewModel> GetAllWheels();
        SearchWheelViewModel LoadDataToViewBag(IEnumerable<WheelViewModel> wheels);
        IEnumerable<WheelViewModel> GetSearchWheelInfo(SearchWheelBindingModel model);
    }
}
