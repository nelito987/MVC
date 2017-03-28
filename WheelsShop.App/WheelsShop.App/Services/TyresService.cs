using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WheelsShop.App.Models.ViewModels;
using WheelsShop.App.Services.Contracts;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.EntityModels;

namespace WheelsShop.App.Services
{
    public class TyresService : BaseService, ITyreService
    {
        public TyresService(IWheelsShopData data) 
            : base(data)
        {
        }

        public IEnumerable<TyreViewModel> GetAllTyres()
        {
            var tyres = this.Data.Products.Where(p => p is Tyre) as IEnumerable<Tyre>;
            tyres.Where(t => t.)
            var tyresVm = Mapper.Map<IEnumerable<TyreViewModel>>(tyres);
            return tyresVm;
        }
    }
}
