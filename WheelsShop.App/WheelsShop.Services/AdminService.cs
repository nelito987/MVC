using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.BindingModels;
using WheelsShop.Models.EntityModels;
using WheelsShop.Services.Contracts;

namespace WheelsShop.Services
{
    public class AdminService : BaseService, IAdminService
    {
        public AdminService(IWheelsShopData data) 
            : base(data)
        {
        }

        public void AddNewTyre(NewTyreBindingModel tyre)
        {
            var newTyre = Mapper.Map<Tyre>(tyre);
            this.Data.Products.Add(newTyre);
            this.Data.SaveChanges();            
        }
    }


}
