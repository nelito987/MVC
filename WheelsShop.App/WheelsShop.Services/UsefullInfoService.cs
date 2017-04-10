using WheelsShop.Data.UnitOfWork;
using WheelsShop.Services.Contracts;

namespace WheelsShop.Services
{
    public class UsefullInfoService : BaseService, IUsefullInfoService
    {
        public UsefullInfoService(IWheelsShopData data) 
            : base(data)
        {
        }
    }
}
