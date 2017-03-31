using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelsShop.App.Models.BindingModels;
using WheelsShop.App.Models.ViewModels;
using WheelsShop.App.Services.Contracts;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.EntityModels;

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
            //var tyres = this.service.GetAllTyres();
            //var vm = this.service.LoadDataToViewBag(tyres);     
            return View();
        }

        public PartialViewResult Search()
        {
            var tyres = this.service.GetAllTyres();
            var vm = this.service.LoadDataToViewBag(tyres);
            return PartialView("TyresDropDown", vm);
        }

        
        //public ActionResult AllTyres()
        //{
        //    IEnumerable<TyreViewModel> tyres = this.service.GetAllTyres();
        //    //todo: move to service
        //    var model = new AllTyresViewModel()
        //    {
        //        TyresVM = tyres
        //    };
        //    return View(model);
        //}       
        
        public ActionResult SearchTyre(SearchTyreBindingModel model)
        {  
            //if(model == null)
            //{
            //    return RedirectToAction("AllTyres");
            //}
            var result = this.service.GetSearchTyreInfo(model);            
            return View(result);
        }
    }
}