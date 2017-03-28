using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelsShop.App.Models.ViewModels;
using WheelsShop.App.Services.Contracts;
using WheelsShop.Data.UnitOfWork;

namespace WheelsShop.App.Controllers
{
    public class TyresController : BaseController
    {
        private readonly ITyreService service;

        public TyresController(IWheelsShopData data, ITyreService service) 
            : base(data)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Tyres Index";
            //var test = this.Data.Products.
            //test.ToString();
            return View();
        }

        public ActionResult AllTyres()
        {
            IEnumerable<TyreViewModel> tyres = this.service.GetAllTyres();
            var model = new AllTyresViewModel()
            {
                TyresVM = tyres
            };
            return View(model);
        }
    }
}