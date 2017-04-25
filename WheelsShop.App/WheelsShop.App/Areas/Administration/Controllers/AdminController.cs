﻿using System.Collections.Generic;
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

        //TODO : child attr
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
            ModelState.Clear();
            return this.View();
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
            ModelState.Clear();
            return RedirectToAction("SearchWheel", "Wheels");
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
            return this.View(order);
        }

        [HttpPost]
        [Route("ChangeOrderStatus")]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeOrderStatus(OrderBindingModel model)
        {
            //TODO if order status is changed to cart to add quantity for product stock
            if (ModelState.IsValid)
            {
                this.service.ChangeOrderStatus(model);
            }
            return this.RedirectToAction("ViewAllOrders");
        }

        [Route("ViewAllOrders")]
        public ActionResult ViewAllOrders()
        {
            IEnumerable<OrderViewModel> orders = this.service.GetAllOrders();            
            if(orders == null)
            {
                this.TempData["noOrdersFound"] = "There are no orders found!!!";
            }
            return this.View(orders);
        }

        [HttpPost]
        [Route("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int id)
        {
            this.service.DeleteProduct(id);
            this.TempData["ProductDeleted"] = "Product has been deleted successfully!!!";

            return this.RedirectToAction("Index", "Home");
        }

        [Route("EditProduct")]
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            ProductViewModel product = this.service.GetEditedProduct(id);
            return this.View(product);
        }

        [Route("EditProduct/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(EditProductBindingModel product)
        {
            this.service.UpdateProduct(product);
            this.TempData["ProductDeleted"] = "Product has been updated successfully!!!";
            return this.RedirectToAction("Index", "Home");
        }
    }
}