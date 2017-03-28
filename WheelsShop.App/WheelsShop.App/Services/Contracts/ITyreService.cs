using System.Collections.Generic;
using WheelsShop.App.Models.ViewModels;

namespace WheelsShop.App.Services.Contracts
{
    public interface ITyreService
    {
        IEnumerable<TyreViewModel> GetAllTyres();
    }
}
