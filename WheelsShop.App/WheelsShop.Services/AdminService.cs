using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Services.Contracts;

namespace WheelsShop.Services
{
    public class AdminService : BaseService, IAdminService
    {
        public AdminService(IWheelsShopData data) 
            : base(data)
        {
        }
    }
}
