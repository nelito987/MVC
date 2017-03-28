using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelsShop.Data.UnitOfWork;

namespace WheelsShop.App.Controllers
{
    public class TyresController : BaseController
    {
        public TyresController(IWheelsShopData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Tyres Index";
            //var test = this.Data.Products.
            //test.ToString();
            return View();
        }

        public ActionResult TyresBySize()
        {
            //var test = this.Data.Tyres.All();
            //test.ToString();
            return View();
        }
    }
}