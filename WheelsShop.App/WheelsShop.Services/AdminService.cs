using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.BindingModels;
using WheelsShop.Models.EntityModels;
using WheelsShop.Models.EntityModels.Enums;
using WheelsShop.Models.ViewModels;
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

        public void AddNewWheel(NewWheelBindingModel wheel)
        {
            var newWheel = Mapper.Map<Wheel>(wheel);
            this.Data.Products.Add(newWheel);
            this.Data.SaveChanges();
        }

        public IEnumerable<OrderViewModel> GetAllOrders()
        {
            IEnumerable<Order> orders = this.Data.Sales.All()
                .OrderBy(o => o.Status)
                .ToList();
            var ordersVm = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders);
            return ordersVm;
        }

        public OrderViewModel GetOrderById(int orderId)
        {
            var order = this.Data.Sales.Find(orderId);
            OrderViewModel orderVm = Mapper.Map<OrderViewModel>(order);
            return orderVm;
        }

        public void ChangeOrderStatus(OrderBindingModel model)
        {
            var order = this.Data.Sales.Find(model.Id);
            Status status = (Status)Enum.Parse(typeof(Status), model.Status);
            Product product = this.Data.Products.Find(order.ProductId);
            order.User = this.Data.Users.Find(order.User.Id);
            try
            {
                order.Status = status;
                this.Data.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName + ": " + x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }
            
        }

        public void DeleteProduct(int id)
        {
            Product product = this.Data.Products.Find(id);
            this.Data.Products.Remove(product);
            this.Data.SaveChanges();
        }

        public ProductViewModel GetEditedProduct(int id)
        {
            var product = this.Data.Products.Find(id);
            ProductViewModel productVm = Mapper.Map<ProductViewModel>(product);
            return productVm;
        }

        public void UpdateProduct(EditProductBindingModel product)
        {
            Tyre tyre = null;
            Wheel wheel = null;
            var curProduct = this.Data.Products.Find(product.Id);
            
            if (curProduct.GetType().BaseType.Name == "Tyre")
            {
                //updatedProduct = Mapper.Map<Tyre>(product);
                tyre = (Tyre)curProduct;
                tyre.Model = product.Model;
                tyre.Price = product.Price;
                tyre.Stock = product.Stock;
                tyre.Height = product.Height;
                tyre.Season = product.Season;
                tyre.Width = product.Width;
                tyre.Size = product.Size;

                this.Data.Products.Update(tyre);
            }
            else if(curProduct.GetType().BaseType.Name == "Wheel")
            {
                wheel = curProduct as Wheel;
                wheel.Model = product.Model;
                wheel.Price = product.Price;
                wheel.Stock = product.Stock;
                wheel.PCD = product.PCD;
                wheel.Size = product.Size;

                this.Data.Products.Update(wheel);
            }
            this.Data.SaveChanges();
            //TODO Double check the inheritanse - do a need a db set for tyres an wheels?
        }

        
    }
}
