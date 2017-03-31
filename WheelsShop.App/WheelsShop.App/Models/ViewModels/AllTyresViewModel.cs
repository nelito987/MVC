using System.Collections.Generic;
using WheelsShop.Models.EntityModels;

namespace WheelsShop.App.Models.ViewModels
{
    // TODO: Rename it beacause its used in searched tyres
    public class AllTyresViewModel
    {
        public IEnumerable<TyreViewModel> TyresVM { get; set; }
    }
}