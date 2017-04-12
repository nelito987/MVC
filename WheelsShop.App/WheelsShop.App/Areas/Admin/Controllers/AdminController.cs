using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelsShop.App.Attributes;
using WheelsShop.App.Controllers;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Services.Contracts;

namespace WheelsShop.App.Areas.Admin.Controllers
{
    [WheelsShopAuthorize(Roles ="Admin")]
    [RouteArea("Admin")]
    public class AdminController: BaseController
    {
        private IAdminService service;

        public AdminController(IWheelsShopData data, IAdminService service) 
            : base(data)
        {
            this.service = service;
        }
    }
}