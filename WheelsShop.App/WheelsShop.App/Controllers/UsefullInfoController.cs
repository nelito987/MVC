using System.Collections.Generic;
using System.Web.Mvc;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.ViewModels;
using WheelsShop.Services.Contracts;

namespace WheelsShop.App.Controllers
{
    public class UsefullInfoController : BaseController
    {
        private readonly IUsefullInfoService service;

        public UsefullInfoController(IWheelsShopData data, IUsefullInfoService service)
            : base(data)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            var sizeDistinct = new List<int>() { 13, 14, 15 };
            IEnumerable<int> widthDistinct = new List<int>() { 13, 14, 15, 16, 17 };
            IEnumerable<int> heightDistinct = new List<int>() { 13, 14, 15, 18, 19};

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