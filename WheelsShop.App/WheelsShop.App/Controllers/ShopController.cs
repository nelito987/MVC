using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using WheelsShop.Data.UnitOfWork;
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
    }
}