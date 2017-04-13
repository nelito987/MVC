using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelsShop.App.Attributes;
using WheelsShop.App.Controllers;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.BindingModels;
using WheelsShop.Services.Contracts;

namespace WheelsShop.App.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [WheelsShopAuthorize(Roles ="Admin")]
    
    public class AdminController: Controller
    {
        private IAdminService service;

        public AdminController(IWheelsShopData data, IAdminService service) 
            //: base(data)
        {
            this.service = service;
        }

        //[Route("AddNewTyre")]
        public ActionResult AddNewTyre()
        {            
            return this.View();
        }

        [HttpPost]
        //[Route("AddNewTyre")]
        public ActionResult AddNewTyre(NewTyreBindingModel tyre)
        {            
            if (ModelState.IsValid)
            {
                this.service.AddNewTyre(tyre);
                this.TempData["TyreAdded"] = "New tyre has been added successfully!!!";
            }
            return this.View();
        }

    }
}