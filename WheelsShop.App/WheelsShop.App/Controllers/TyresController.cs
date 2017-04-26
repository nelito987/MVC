using System.Collections.Generic;
using System.Web.Mvc;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.BindingModels;
using WheelsShop.Models.ViewModels;
using WheelsShop.Services.Contracts;

namespace WheelsShop.App.Controllers
{
    [RoutePrefix("Tyres")]
    public class TyresController : BaseController
    {
        private readonly ITyreService service;

        public TyresController(IWheelsShopData data, ITyreService service) 
            : base(data)
        {
            this.service = service;
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

        [Route("SearchTyre")]
        public ActionResult SearchTyre(SearchTyreBindingModel model)
        {
             var result = this.service.GetSearchTyreInfo(model);
             return View(result);
        }        
    }
}