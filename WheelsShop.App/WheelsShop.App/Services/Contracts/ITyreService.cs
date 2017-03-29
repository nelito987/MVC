using System.Collections.Generic;
using WheelsShop.App.Models.ViewModels;
using WheelsShop.Models.EntityModels;

namespace WheelsShop.App.Services.Contracts
{
    public interface ITyreService
    {
        IEnumerable<TyreViewModel> GetAllTyres();

        IEnumerable<Tyre> GetSearchTyreInfo();
    }
}
