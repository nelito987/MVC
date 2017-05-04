using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult SearchTyre(SearchTyreBindingModel model, string sortOrder, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.BrandSortParam = sortOrder == "Brand" ? "brand_desc" : "Brand";
            var result = this.service.GetSearchTyreInfo(model, page);

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
    }
}