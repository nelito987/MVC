using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var tyres = this.service.GetSearchTyreInfo(); 
            var vm = LoadDataToViewBag(tyres);   
            return View(vm);
        }

        private SearchTyreViewModel LoadDataToViewBag(IEnumerable<Tyre> tyres)
        {
            IEnumerable<int> sizeDistinct = tyres.Select(t => t.Size).Distinct();
            IEnumerable<int> widthDistinct = tyres.Select(t => t.Width).Distinct();
            IEnumerable<int> heightDistinct = tyres.Select(t => t.Height).Distinct();
            IEnumerable<string> seasonsDistinct = tyres.Select(t => t.Season.ToString()).Distinct();
            IEnumerable<string> tyreBrands = tyres.Select(t => t.Brand).Distinct();

            var sizes = new SelectList(sizeDistinct);
            var width = new SelectList(widthDistinct);
            var heights = new SelectList(heightDistinct);
            var seasons = new SelectList(seasonsDistinct);
            var brands = new SelectList(tyreBrands);

            //ViewBag.Sizes = sizes.Select(t => new SelectListItem()
            //{
            //    Text = t.Text,
            //    Value = t.Value
            //});
            //ViewBag.Width = width.Select(t => new SelectListItem()
            //{
            //    Text = t.Text,
            //    Value = t.Value
            //});
            //ViewBag.Height = heights.Select(t => new SelectListItem()
            //{
            //    Text = t.Text,
            //    Value = t.Value
            //});
            //ViewBag.Seasons = seasons.Select(t => new SelectListItem()
            //{
            //    Text = t.Text,
            //    Value = t.Value
            //});
            //ViewBag.Brands = brands.Select(t => new SelectListItem()
            //{
            //    Text = t.Text,
            //    Value = t.Value
            //});

            var vm = new SearchTyreViewModel()
            {
                Sizes = sizes,
                Widths = width,
                Height = heights,
                Seasons = seasons,
                Brands = brands
            };

            return vm;
        }

       

        public ActionResult AllTyres()
        {
            IEnumerable<TyreViewModel> tyres = this.service.GetAllTyres();
            //todo: move to service
            var model = new AllTyresViewModel()
            {
                TyresVM = tyres
            };
            return View(model);
        }

        public ActionResult GetSearchTyreInfo()
        {
            var result = this.service.GetSearchTyreInfo();
            
            return View(result);
        }
    }
}