﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using WheelsShop.App.Attributes;
using WheelsShop.App.Controllers;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.BindingModels;
using WheelsShop.Models.ViewModels;
using WheelsShop.Services.Contracts;

namespace WheelsShop.App.Areas.Administration.Controllers
{
    [WheelsShopAuthorize(Roles = "Admin")]
    [RouteArea("Administration")]
    public class AdminController : BaseController
    {
        private IAdminService service;

        public AdminController(IWheelsShopData data, IAdminService service)
        : base(data)
        {
            this.service = service;
        }
        
        [Route("AddNewTyre")]
        public ActionResult AddNewTyre()
        {
            return this.View();
        }

        [HttpPost]
        [Route("AddNewTyre")]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewTyre(NewTyreBindingModel tyre)
        {                
            if (ModelState.IsValid)
            {
                this.service.AddNewTyre(tyre);
                this.TempData["TyreAdded"] = "New tyre has been added successfully!!!";
            }
            else
            {
                this.TempData["ProductNotAdded"] = "Product has not been added, because of invalid input data!!!";
            }
            return this.RedirectToAction("AddNewProduct");
        }

        [Route("AddNewWheel")]
        public ActionResult AddNewWheel()
        {
            return this.View();
        }

        [HttpPost]
        [Route("AddNewWheel")]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewWheel(NewWheelBindingModel wheel)
        {
            if (ModelState.IsValid)
            {
                this.service.AddNewWheel(wheel);
                this.TempData["WheelAdded"] = "New wheel has been added successfully!!!";
            }
            else
            {
                this.TempData["ProductNotAdded"] = "Product has not been added, because of invalid input data!!!";
            }
            
            return this.RedirectToAction("AddNewProduct");
        }

        [Route("AddNewProduct")]
        public ActionResult AddNewProduct()
        {
            return this.View();
        }

        [HttpGet]
        [Route("ChangeOrderStatus")]
        public ActionResult ChangeOrderStatus(int orderId)
        {
            var order = this.service.GetOrderById(orderId); 
            if(order == null)
            {
                ModelState.AddModelError("Order", "Order with this ID has not been found!");
            }           
            return this.View(order);
        }

        [HttpPost]
        [Route("ChangeOrderStatus")]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeOrderStatus(OrderBindingModel model)
        {            
            if (ModelState.IsValid)
            {
                this.service.ChangeOrderStatus(model);
            }
            return this.RedirectToAction("ViewAllOrders");
        }

        [Route("ViewAllOrders")]
        public ActionResult ViewAllOrders(string sortOrder)
        {
            IEnumerable<OrderViewModel> orders = this.service.GetAllOrders();            
            if(orders == null)
            {
                this.TempData["noOrdersFound"] = "There are no orders found!!!";
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.BrandSortParam = sortOrder == "Brand" ? "brand_desc" : "Brand";
            ViewBag.OrderNumberSortParam = sortOrder == "OrderNumber" ? "orderNumber_desc" : "OrderNumber";
            ViewBag.OrderDate = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.ProductId = sortOrder == "ProductId" ? "productId_desc" : "ProductId";
            ViewBag.ModelParam = sortOrder == "Model" ? "model_desc" : "Model";
            ViewBag.SizeParam = sortOrder == "Size" ? "size_desc" : "Size";
            ViewBag.Quantity = sortOrder == "Quantity" ? "quantity_desc" : "Quantity";
            ViewBag.Price = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.TotalPrice = sortOrder == "TotalPrice" ? "totalPrice_desc" : "TotalPrice";
            ViewBag.Status = sortOrder == "Status" ? "status_desc" : "Status";

            orders = this.service.SortBySelectedOrder(orders, sortOrder);

           
            return this.View(orders);
        }

        [HttpPost]
        [Route("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int id)
        {                      
            this.service.DeleteProduct(id);
            this.TempData["ProductDeleted"] = "Product has been deleted successfully!!!";

            return this.RedirectToAction("Index", "Home", new { area = "" });
        }

        [Route("EditProduct")]
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            ProductViewModel product = this.service.GetEditedProduct(id);
            if(product == null)
            {
                return this.HttpNotFound("The selected product was not found");
            }
            return this.View(product);
        }

        [Route("EditProduct/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(EditProductBindingModel product)
        {
            if (ModelState.IsValid)
            {
                this.service.UpdateProduct(product);
                this.TempData["ProductDeleted"] = "Product has been updated successfully!!!";
            }            
            return this.RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}