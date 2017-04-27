using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        public WheelViewModel ViewWheel(int productId)
        {
            Wheel product = this.Data.Products.Find(productId) as Wheel;
            var productVm = Mapper.Map<WheelViewModel>(product);
            return productVm;
        }

        public bool AddToCart(int productId, string userId, int quantity)
        {
            var user = this.Data.Users.Find(userId);
            Product product = this.Data.Products.Find(productId);
            if(product.Stock >= quantity)
            {
                Order newOrder = new Order()
                {
                    User = user,
                    ProductId = productId,
                    Product = product,
                    Quantity = quantity,
                    Status = Status.Cart,
                    OrderDate = DateTime.Now
                };
                this.Data.Sales.Add(newOrder);
                user.ProductsBought.Add(newOrder);
                product.Stock -= quantity;
                this.Data.SaveChanges();
                return true;
            }

            return false;            
        }

        public IEnumerable<OrderViewModel> GetOrdersInCart(string userId)
        {
            var user = this.Data.Users.Find(userId);
            var orders = user.ProductsBought.Where(o => o.Status == Status.Cart).ToList();
            var ordersVm = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders);
            
            return ordersVm;
        }

        public void ChangeOrderStatusToProcessing(int[] orderIds)
        {
            //TODO validate if ordersId is null

            foreach (var orderId in orderIds)
            {
                var curOrder = this.Data.Sales.Find(orderId);
                curOrder.Status = Status.Processing;
                Product product = this.Data.Products.Find(curOrder.ProductId);
                curOrder.User = this.Data.Users.Find(curOrder.User.Id);
                this.Data.Sales.Update(curOrder);
            }

            try
            {
                this.Data.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName + ": " + x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }
        }

        public IEnumerable<OrderViewModel> GetAllOrdersForUser(string userId)
        {
            var orders = this.Data.Sales
                .Where(u => u.User.Id == userId)
                .OrderByDescending(s => s.OrderDate)
                .ToList();
            var ordersVm = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders);
            return ordersVm;
        }

        public void RemoveItemFromCart(int orderId)
        {           
            var orderToBeRemoved = this.Data.Sales.Find(orderId);
            var product = orderToBeRemoved.Product;
            product.Stock += orderToBeRemoved.Quantity;            
            this.Data.Sales.Remove(orderToBeRemoved);
            this.Data.SaveChanges();
        }

        public string GetProductDescriptionById(int id)
        {
            string description = this.Data.Products.Find(id).Description;
            return description;
        }
    }
}

