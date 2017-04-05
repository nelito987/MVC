using WheelsShop.Data.UnitOfWork;

namespace WheelsShop.Services
{
    public abstract class BaseService
    {
        protected IWheelsShopData data;

        protected BaseService(IWheelsShopData data)
        {
            this.Data = data;
        }

        protected IWheelsShopData Data { get; private set; }
    }
}
