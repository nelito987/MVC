using System.Collections.Generic;
using WheelsShop.Models.BindingModels;
using WheelsShop.Models.EntityModels;
using WheelsShop.Models.ViewModels;

namespace WheelsShop.Services.Contracts
{
    public interface ITyreService
    {
        IEnumerable<TyreViewModel> GetAllTyresVM();
        IEnumerable<Tyre> GetAllTyres();
        SearchTyreViewModel LoadDataToViewBag(IEnumerable<Tyre> tyres);
        IEnumerable<TyreViewModel> GetSearchTyreInfo(SearchTyreBindingModel model, int? page);
    }
}
