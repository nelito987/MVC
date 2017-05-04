using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WheelsShop.Models.ViewModels;
using WheelsShop.Services.Contracts;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.EntityModels;
using System.Web.Mvc;
using WheelsShop.Models.BindingModels;
using System.Net;

namespace WheelsShop.Services
{
    public class TyresService : BaseService, ITyreService
    {
        public TyresService(IWheelsShopData data) 
            : base(data)
        {
        }

        public IEnumerable<TyreViewModel> GetAllTyresVM()
        {
            var tyres = this.Data.Products
                .Where(p => p is Tyre && p.Stock > 0)
                .OrderBy(p => p.Price)
                .ToList();
            var tyresVm = Mapper.Map<IEnumerable<TyreViewModel>>(tyres);
            return tyresVm;
        }

        public IEnumerable<Tyre> GetAllTyres()
        {
            var tyres = this.Data.Tyres                
                .Where(p => p.Stock > 0)
                .OrderBy(p => p.Price)
                .ToList();

            return tyres;
        }

        public IEnumerable<TyreViewModel> GetSearchTyreInfo(SearchTyreBindingModel model, int? page)
        {
            var tyres = this.GetAllTyres();

            if(model.Brands != null)
            {
                tyres = tyres.Where(p => p.Brand == model.Brands);
            }
            if (model.Seasons != null)
            {
                tyres = tyres.Where(p => p.Season.ToString() == model.Seasons);
            }
            if (model.Sizes != 0)
            {
                tyres = tyres.Where(p => p.Size == model.Sizes);
            }
            if (model.Widths != 0)
            {
                tyres = tyres.Where(p => p.Width == model.Widths);
            }
            if (model.Height != 0)
            {
                tyres = tyres.Where(p => p.Height == model.Height);
            }         
           

            var tyresVm = Mapper.Map<IEnumerable<TyreViewModel>>(tyres);           
            return tyresVm;
        }

        public SearchTyreViewModel LoadDataToViewBag(IEnumerable<Tyre> tyres)
        {
            if(tyres == null)
            {
                new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid search");               
            }
            IEnumerable<int> sizeDistinct = tyres.Where(t => t.Stock > 0).Select(t => t.Size).Distinct();
            IEnumerable<int> widthDistinct = tyres.Where(t => t.Stock > 0).Select(t => t.Width).Distinct();
            IEnumerable<int> heightDistinct = tyres.Where(t => t.Stock > 0).Select(t => t.Height).Distinct();
            IEnumerable<string> seasonsDistinct = tyres.Where(t => t.Stock > 0).Select(t => t.Season.ToString()).Distinct();
            IEnumerable<string> tyreBrands = tyres.Select(t => t.Brand).Distinct();           

            var sizes = new SelectList(sizeDistinct);
            var width = new SelectList(widthDistinct);
            var heights = new SelectList(heightDistinct);
            var seasons = new SelectList(seasonsDistinct);
            var brands = new SelectList(tyreBrands);
            
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
    }
}
