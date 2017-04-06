using AutoMapper;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.EntityModels;
using WheelsShop.Models.ViewModels;
using WheelsShop.Services.Contracts;

namespace WheelsShop.Services
{
    public class ShopService : BaseService, IShopService
    {
        public ShopService(IWheelsShopData data)
            : base(data)
        {
        }

        public TyreViewModel ViewProduct(int productId)
        {
            //var user = this.Data.Users.Find(userId);
            Tyre product = this.Data.Products.Find(productId) as Tyre;

            //Order newOrder = new Order()
            //{
            //    User = user,
            //    Product = 
            //}

            var productVm = Mapper.Map<TyreViewModel>(product);
            return productVm;
        }
    }
}

