using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.ViewModels;
using WheelsShop.Services.Contracts;

namespace WheelsShop.App.Controllers
{
    [RoutePrefix("shop")]
    public class ShopController : BaseController
    {
        private readonly IShopService service;

        public ShopController(IWheelsShopData data, IShopService service)
            : base(data)
        {
            this.service = service;
        }

        public ActionResult BuyTyres(int productId)
        {
            //var userId = User.Identity.GetUserId();
            var tyre = this.service.ViewProduct(productId);
            return this.View(tyre);
        }

        [HttpPost]
        public ActionResult AddToCart(int productId, int quantity)
        {
            var userId = User.Identity.GetUserId();
            this.service.AddToCart(productId, userId, quantity);
            return RedirectToAction("ViewCart");
        }

        public ActionResult ViewCart()
        {
            var userId = User.Identity.GetUserId();
            var orders = this.service.GetOrdersInCart(userId);
            return this.View(orders);
        }

        public ActionResult ConfirmOrders(int[] orderIds)
        {
            this.service.ChangeOrderStatusToProcessing(orderIds);
            this.TempData["confirmedOrder"] = "Your order has been confirm successfully!!!";
            return this.RedirectToAction("ViewAllOrders");
        }

        public ActionResult ViewAllOrders()
        {
            var userId = User.Identity.GetUserId();
            IEnumerable<OrderViewModel> ordersVm = this.service.GetAllOrdersForUser(userId);
            return this.View(ordersVm);
        }

        public ActionResult DeleteProductFromCart(int orderId)
        {
            var userId = User.Identity.GetUserId();
            this.service.RemoveItemFromCart(userId, orderId);
            return this.RedirectToAction("ViewCart");
        }
    }
}