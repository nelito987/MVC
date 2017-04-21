using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WheelsShop.Models.ViewModels;
using WheelsShop.Services.Contracts;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.EntityModels;
using System.Web.Mvc;
using WheelsShop.Models.BindingModels;

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
            var tyres = this.Data.Products.Where(p => p is Tyre).ToList();
            var tyresVm = Mapper.Map<IEnumerable<TyreViewModel>>(tyres);
            return tyresVm;
        }

        public IEnumerable<Tyre> GetAllTyres()
        {
            return this.Data.Products.All().OfType<Tyre>().ToList();
        }

        public IEnumerable<TyreViewModel> GetSearchTyreInfo(SearchTyreBindingModel model)
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
           

            var tyresVm = Mapper.Map<IEnumerable<TyreViewModel>>(tyres);           
            return tyresVm;
        }

        public SearchTyreViewModel LoadDataToViewBag(IEnumerable<Tyre> tyres)
        {
            IEnumerable<int> sizeDistinct = tyres.Select(t => t.Size).Distinct();
            IEnumerable<int> widthDistinct = tyres.Select(t => t.Width).Distinct();
            IEnumerable<int> heightDistinct = tyres.Select(t => t.Height).Distinct();
            IEnumerable<string> seasonsDistinct = tyres.Select(t => t.Season.ToString()).Distinct();
            IEnumerable<string> tyreBrands = tyres.Select(t => t.Brand).Distinct();
            List<string> orders = new List<string>() {"Price", "Brand", "Size"};
           
            var sizes = new SelectList(sizeDistinct);
            var width = new SelectList(widthDistinct);
            var heights = new SelectList(heightDistinct);
            var seasons = new SelectList(seasonsDistinct);
            var brands = new SelectList(tyreBrands);
            var order = new SelectList(orders);
            

            var vm = new SearchTyreViewModel()
            {
                Sizes = sizes,
                Widths = width,
                Height = heights,
                Seasons = seasons,
                Brands = brands//,
                //Order = order
            };

            return vm;
        }
    }
}
