using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.BindingModels;
using WheelsShop.Models.EntityModels;
using WheelsShop.Models.ViewModels;
using WheelsShop.Services.Contracts;

namespace WheelsShop.App.Controllers
{
    
    public class WheelsController : BaseController
    {
        private readonly IWheelsService service;

        public WheelsController(IWheelsShopData data, IWheelsService service) 
            : base(data)
        {
            this.service = service;
        }

        [Route("SearchWheel")]
        public ActionResult SearchWheel(SearchWheelBindingModel model)
        {
            
                var result = this.service.GetSearchWheelInfo(model);
                return View(result);
           
        }       

        public PartialViewResult Search()
        {
            var wheels = this.service.GetAllWheels();
            SearchWheelViewModel vm = null;
            if (wheels != null)
            {
                vm = this.service.LoadDataToViewBag(wheels);
            }
            return PartialView("_WheelsDropDown", vm);            
        }
    }
}