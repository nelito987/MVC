using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WheelsShop.App.Models.ViewModels;
using WheelsShop.App.Services.Contracts;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.EntityModels;
using System.Web.Mvc;
using System;
using WheelsShop.App.Models.BindingModels;

namespace WheelsShop.App.Services
{
    public class TyresService : BaseService, ITyreService
    {
        public TyresService(IWheelsShopData data) 
            : base(data)
        {
        }

        public IEnumerable<TyreViewModel> GetAllTyres()
        {
            var tyres = this.Data.Products.Where(p => p is Tyre).ToList();
            var tyresVm = Mapper.Map<IEnumerable<TyreViewModel>>(tyres);
            return tyresVm;
        }

        public IEnumerable<Tyre> GetSearchTyreInfo()
        {
            //var tyres = this.Data.Products.Where(p => p is Tyre).ToList();
            //var tyres = this.Data.Products.All().OfType<Tyre>().ToList();
            //IEnumerable<int> widthDistinct = tyres.Select(t => t.Width).Distinct();
            //IEnumerable<int> heightDistinct = tyres.Select(t => t.Height).Distinct();
            //IEnumerable<int> sizeDistinct = tyres.Select(t => t.Size).Distinct();
            //IEnumerable<string> tyreBrands = tyres.Select(t => t.Brand).Distinct();

            //var model = new SearchTyreViewModel()
            //{
            //    Widths = widthDistinct,
            //    Height = heightDistinct,
            //    Sizes = sizeDistinct,
            //    Brands = tyreBrands
            //};          

            //return model;

            return this.Data.Products.All().OfType<Tyre>().ToList();
        }

        public AllTyresViewModel GetSearchTyreInfo(SearchTyreBindingModel model)
        {
            var tyres = this.Data.Products.All().OfType<Tyre>();
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


            //var tyres = this.Data.Products.All().OfType<Tyre>()
            //     .Where(p => (p.Brand == model.Brands || model.Brands == null) &&
            //            (p.Season.ToString() == model.Seasons || model.Seasons == null) &&
            //            (p.Width == model.Widths || p.Width == 0) &&
            //            (p.Height == model.Height || p.Height == 0) &&
            //            (p.Size == model.Sizes || p.Size == 0));

            var tyresVm = Mapper.Map<IEnumerable<TyreViewModel>>(tyres);
            var searchedTyresVm = new AllTyresViewModel()
            {
                TyresVM = tyresVm
            };
            return searchedTyresVm;
        }

        public SearchTyreViewModel LoadDataToViewBag(IEnumerable<Tyre> tyres)
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
