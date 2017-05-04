using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
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
            byte[] file = this.FileUpload(tyre.ImageUrl);
            var newTyre = Mapper.Map<Tyre>(tyre);
            newTyre.ImageUrl = file;
            this.Data.Products.Add(newTyre);
            this.Data.SaveChanges();            
        }
        public void AddNewWheel(NewWheelBindingModel wheel)
        {
            byte[] file = this.FileUpload(wheel.ImageUrl);  
            var newWheel = Mapper.Map<Wheel>(wheel);
            newWheel.ImageUrl = file;
            this.Data.Products.Add(newWheel);
            this.Data.SaveChanges();
        }

        private byte[] FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images"), pic);
                // file is uploaded
                file.SaveAs(path);
                MemoryStream ms = new MemoryStream();
                file.InputStream.CopyTo(ms);
                byte[] array = ms.GetBuffer();

                return ms.ToArray();
            }

            return null;
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
                tyre = (Tyre)curProduct;
                tyre.Brand = product.Brand;
                tyre.Model = product.Model;
                tyre.Price = product.Price;
                tyre.Stock = product.Stock;
                tyre.Height = product.Height;
                tyre.Season = product.Season;
                tyre.Width = product.Width;
                tyre.Size = product.Size;
                tyre.Description = product.Description;

                if(product.ImageUrl != null)
                {
                    byte[] file = this.FileUpload(product.ImageUrl);
                    tyre.ImageUrl = file;
                }

                this.Data.Products.Update(tyre);
            }
            else if(curProduct.GetType().BaseType.Name == "Wheel")
            {
                wheel = curProduct as Wheel;
                wheel.Brand = product.Brand;
                wheel.Model = product.Model;
                wheel.Price = product.Price;
                wheel.Stock = product.Stock;
                wheel.PCD = product.PCD;
                wheel.Description = product.Description;
                wheel.Size = product.Size;

                if (product.ImageUrl != null)
                {
                    byte[] file = this.FileUpload(product.ImageUrl);
                    wheel.ImageUrl = file;
                }

                this.Data.Products.Update(wheel);
            }
            this.Data.SaveChanges();            
        }       

        public IEnumerable<OrderViewModel> SortBySelectedOrder(IEnumerable<OrderViewModel> orders, string sortOrder)
        { 
            switch (sortOrder)
            {
                
                case "Brand":
                    orders = orders.OrderBy(s => s.Product.Brand);
                    break;
                case "brand_desc":
                    orders = orders.OrderByDescending(s => s.Product.Brand);
                    break;
                case "Date":
                    orders = orders.OrderBy(s => s.OrderDate);
                    break;
                case "date_desc":
                    orders = orders.OrderByDescending(s => s.OrderDate);
                    break;
                case "ProductId":
                    orders = orders.OrderBy(s => s.ProductId);
                    break;
                case "productId_desc":
                    orders = orders.OrderByDescending(s => s.ProductId);
                    break;
                case "Model":
                    orders = orders.OrderBy(s => s.Product.Model);
                    break;
                case "model_desc":
                    orders = orders.OrderByDescending(s => s.Product.Model);
                    break;
                case "Size":
                    orders = orders.OrderBy(s => s.Product.Size);
                    break;
                case "size_desc":
                    orders = orders.OrderByDescending(s => s.Product.Size);
                    break;
                case "Quantity":
                    orders = orders.OrderBy(s => s.Quantity);
                    break;
                case "quantity_desc":
                    orders = orders.OrderByDescending(s => s.Quantity);
                    break;
                case "Price":
                    orders = orders.OrderBy(s => s.Product.Price);
                    break;
                case "price_desc":
                    orders = orders.OrderByDescending(s => s.Product.Price);
                    break;
                case "TotalPrice":
                    orders = orders.OrderBy(s => s.Product.Price*s.Quantity);
                    break;
                case "totalPrice_desc":
                    orders = orders.OrderByDescending(s => s.Product.Price * s.Quantity);
                    break;
                case "Status":
                    orders = orders.OrderBy(s => s.Status);
                    break;
                case "status_desc":
                    orders = orders.OrderByDescending(s => s.Status);
                    break;                
                case "orderNumber_desc":
                    orders = orders.OrderByDescending(s => s.Id);
                    break;
                case "OrderNumber":
                    orders = orders.OrderBy(s => s.Id);
                    break;
                default:
                    orders = orders.OrderBy(s => s.Id);
                    break;
            }

            return orders;
        }
    }
}
