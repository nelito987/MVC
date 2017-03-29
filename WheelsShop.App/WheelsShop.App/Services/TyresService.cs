using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WheelsShop.App.Models.ViewModels;
using WheelsShop.App.Services.Contracts;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.EntityModels;
using System.Web.Mvc;

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



        public void test()
        {
            var tyres = this.Data.Products.Where(p => p is Tyre).ToList();
            
        }
    }
}
