using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WheelsShop.App.Models.ViewModels;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.EntityModels;
using WheelsShop.Services.Contracts;

namespace WheelsShop.Services
{
    public class TyresService : BaseService, ITyreService
    {
        public TyresService(IWheelsShopData data) 
            : base(data)
        {
        }

        public IEnumerable<TyreViewModel> GetAllTyres()
        {
            IEnumerable<Tyre> tyres = this.Data.Products.Where(p => p.GetType() == typeof(Tyre)) as IEnumerable<Tyre>;
            var tyresVm = Mapper.Map<IEnumerable<TyreViewModel>>(tyres);
            return tyresVm;
        }
    }
}
