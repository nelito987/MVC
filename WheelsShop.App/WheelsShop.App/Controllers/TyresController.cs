using System.Collections.Generic;
using System.Web.Mvc;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.BindingModels;
using WheelsShop.Models.ViewModels;
using WheelsShop.Services.Contracts;

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
            return View();
        }

        public PartialViewResult Search()
        {
            var tyres = this.service.GetAllTyres();
            SearchTyreViewModel vm = null;
            if(tyres != null)
            {
                vm = this.service.LoadDataToViewBag(tyres);
            }            
            return PartialView("_TyresDropDown", vm);
        }       

        public ActionResult SearchTyre(SearchTyreBindingModel model)
        {
            //if (model != null && this.ModelState.IsValid)
            //{
                var result = this.service.GetSearchTyreInfo(model);
                return View(result);
            //}

            //return this.View();
        }        
    }
}