using System.Collections.Generic;
using WheelsShop.Models.EntityModels;

namespace WheelsShop.App.Models.ViewModels
{
    public class AllTyresViewModel
    {
        public IEnumerable<TyreViewModel> TyresVM { get; set; }
    }
}