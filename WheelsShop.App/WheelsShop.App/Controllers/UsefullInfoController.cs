using System.Collections.Generic;
using System.Web.Mvc;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.ViewModels;
using WheelsShop.Services.Contracts;

namespace WheelsShop.App.Controllers
{
    [RoutePrefix("UsefullInfo")]
    public class UsefullInfoController : BaseController
    {
        private readonly IUsefullInfoService service;

        public UsefullInfoController(IWheelsShopData data, IUsefullInfoService service)
            : base(data)
        {
            this.service = service;
        }

        [Route("Index")]
        public ActionResult Index()
        {
            //TODO extract in private property
            var sizeDistinct = new List<int>() { 13, 14, 15, 16, 17, 18, 19, 21, 22, 23 };
            IEnumerable<int> widthDistinct = new List<int>() { 155, 165, 175, 185, 195, 205, 215, 225, 235, 245, 255, 265, 275, 285, 295, 305, 315, 325};
            IEnumerable<int> heightDistinct = new List<int>() { 20, 25, 30, 35, 40, 45, 55, 60, 65, 70, 75 };

            var sizes = new SelectList(sizeDistinct);
            var width = new SelectList(widthDistinct);
            var heights = new SelectList(heightDistinct);

            var vm = new CalculatorViewModel()
            {
                Sizes = sizes,
                Widths = width,
                Height = heights,
            };            
            return this.View(vm);
        }
    }
}