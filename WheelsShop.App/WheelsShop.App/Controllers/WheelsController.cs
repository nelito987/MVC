using PagedList;
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
        public ActionResult SearchWheel(SearchWheelBindingModel model,string sortOrder, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.BrandSortParam = sortOrder == "Brand" ? "brand_desc" : "Brand";
           

            var result = this.service.GetSearchWheelInfo(model);
            switch (sortOrder)
            {
                case "name_desc":
                    result = result.OrderByDescending(s => s.Price);
                    break;
                case "Brand":
                    result = result.OrderBy(s => s.Brand);
                    break;
                case "brand_desc":
                    result = result.OrderByDescending(s => s.Brand);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(result.ToPagedList(pageNumber, pageSize));          
           
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