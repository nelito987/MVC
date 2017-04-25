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

        [Route("BuyTyres")]
        [AllowAnonymous]
        public ActionResult BuyTyres(int productId)
        {            
            var tyre = this.service.ViewProduct(productId);
            return this.View(tyre);
        }

        [Route("BuyWheels")]
        [AllowAnonymous]
        public ActionResult BuyWheels(int productId)
        {           
            WheelViewModel wheel = this.service.ViewWheel(productId);
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
            this.service.AddToCart(productId, userId, quantity);
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
            return this.View(orders);
        }

        [HttpPost]
        [Route("ConfirmOrders")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmOrders(int[] orderIds)
        {
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