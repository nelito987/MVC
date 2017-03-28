using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelsShop.App.Models.ViewModels;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.EntityModels;
using WheelsShop.Services.Contracts;

namespace WheelsShop.Services
{
    public class TyresService : BaseService
    {
        public TyresService(IWheelsShopData data) 
            : base(data)
        {
        }

        public IQueryable<TyreViewModel> GetAllTyres()
        {
            var tyres = this.Data.Products.Where(p => p.GetType() == typeof(Tyre));
                            
        }
    }
}
