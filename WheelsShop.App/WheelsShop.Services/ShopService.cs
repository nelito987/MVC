using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.EntityModels;
using WheelsShop.Models.EntityModels.Enums;
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
            Tyre product = this.Data.Products.Find(productId) as Tyre;
            var productVm = Mapper.Map<TyreViewModel>(product);
            return productVm;
        }

        public void AddToCart(int productId, string userId, int quantity)
        {
            var user = this.Data.Users.Find(userId);
            Product product = this.Data.Products.Find(productId);

            Order newOrder = new Order()
            {
                User = user,
                ProductId = productId,
                Product = product,
                Quantity = quantity,
                Status = Status.Cart
            };
            this.Data.Sales.Add(newOrder);
            product.Stock -= quantity;
            user.ProductsBought.Add(newOrder);
            this.Data.SaveChanges();
        }

        public CartViewModel GetOrdersInCart(string userId)
        {
            var user = this.Data.Users.Find(userId);
            //var ordersU = this.Data.Sales.Where(s => s.User == user && s.Status == Status.Cart).AsEnumerable();
            var orders = user.ProductsBought.Where(o => o.Status == Status.Cart);
            var ordersVm = Mapper.Map<CartViewModel>(orders);
            return ordersVm;
        }
    }
}

