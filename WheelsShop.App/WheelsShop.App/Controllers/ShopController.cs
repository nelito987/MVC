using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.ViewModels;
using WheelsShop.Services.Contracts;
using WheelsShop.App.Attributes;
using System.Net;

namespace WheelsShop.App.Controllers
{    
    [RoutePrefix("shop")]
    [Authorize]
    public class ShopController : BaseController
    {
        private readonly IShopService service;

        public ShopController(IWheelsShopData data, IShopService service)
            : base(data)
        {
            this.service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public string GetDescription(int id)
        {            
            string description = this.service.GetProductDescriptionById(id);
            return description;
        }

        [Route("BuyTyres")]
        [AllowAnonymous]
        public ActionResult BuyTyres(int productId)
        {            
            var tyre = this.service.ViewProduct(productId);
            if (tyre == null)
            {
                return this.HttpNotFound("Tyre can not be found!");
            }
            return this.View(tyre);
        }

        [Route("BuyWheels")]
        [AllowAnonymous]
        public ActionResult BuyWheels(int productId)
        {           
            WheelViewModel wheel = this.service.ViewWheel(productId);
            if (wheel == null)
            {
                return this.HttpNotFound("Wheel with such id can not be found");
            }
            return this.View(wheel);
        }

        [HttpPost]
        [Route("AddToCart")]
        [ValidateAntiForgeryToken]        

        public ActionResult AddToCart(int productId, int quantity)
        {
            var userId = User.Identity.GetUserId();

            if (userId == null)
            {
                new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error with identification the user");
            } 

            if(quantity < 0)
            {
                ModelState.AddModelError("Stock", "Quantity can not be negative");
            }     
                  
            var addToCart = this.service.AddToCart(productId, userId, quantity);

            if(addToCart == false)
            {
                this.TempData["notEnoughQuantity"] = "The quantity on stock is not enough for your order!!! Order has not been added";
            }

            return RedirectToAction("ViewCart");

        }

        [Route("ViewCart")]
        public ActionResult ViewCart()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error with identification the user");
            }

            var orders = this.service.GetOrdersInCart(userId);   
            if(orders == null)
            {
                ModelState.AddModelError("Orders", "No orders for this user are found!");
            }         
            return this.View(orders);
        }

        [HttpPost]
        [Route("ConfirmOrders")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmOrders(int[] orderIds)
        {
            if (orderIds == null)
            {
                ModelState.AddModelError("Orders", "Orders are not found");
            }
            this.service.ChangeOrderStatusToProcessing(orderIds);
            this.TempData["confirmedOrder"] = "Your order has been confirm successfully!!!";
            return this.RedirectToAction("ViewAllOrders");
        }

        [Route("ViewAllOrders")]       
        public ActionResult ViewAllOrders()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error with identification the user");
            }
            IEnumerable<OrderViewModel> ordersVm = this.service.GetAllOrdersForUser(userId);
            return this.View(ordersVm);
        }

        [HttpPost]
        [Route("DeleteProductFromCart/{orderId}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProductFromCart(int orderId)
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error with identification the user");
            }
            this.service.RemoveItemFromCart(userId, orderId);
            return this.RedirectToAction("ViewCart");
        }
    }
}