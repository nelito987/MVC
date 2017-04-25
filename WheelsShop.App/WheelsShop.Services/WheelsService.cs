using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WheelsShop.Data.UnitOfWork;
using WheelsShop.Models.BindingModels;
using WheelsShop.Models.EntityModels;
using WheelsShop.Models.ViewModels;
using WheelsShop.Services.Contracts;

namespace WheelsShop.Services
{
    public class WheelsService : BaseService, IWheelsService
    {
        public WheelsService(IWheelsShopData data) 
            : base(data)
        {
        }

        public IEnumerable<WheelViewModel> GetAllWheels()
        {
            var wheels = this.Data.Products
                .Where(p => p is Wheel && p.Stock > 0)
                .OrderBy(p => p.Price)
                .ToList();
            var wheelsVm = Mapper.Map<IEnumerable<WheelViewModel>>(wheels);
            return wheelsVm;
        }

        public IEnumerable<WheelViewModel> GetSearchWheelInfo(SearchWheelBindingModel model)
        {
            var wheels = this.GetAllWheels();

            if (model.Brands != null)
            {
                wheels = wheels.Where(p => p.Brand == model.Brands);
            }
            if (model.PCDs != null)
            {
                wheels = wheels.Where(p => p.PCD == model.PCDs);
            }
            if (model.Sizes != 0)
            {
                wheels = wheels.Where(p => p.Size == model.Sizes);
            } 

           // var wheelsVm = Mapper.Map<IEnumerable<WheelViewModel>>(wheels);
            return wheels;
        }

        public SearchWheelViewModel LoadDataToViewBag(IEnumerable<WheelViewModel> wheels)
        {
            //TODO change double to int
            SearchWheelViewModel vm = null;

            if (wheels != null)
            {
                IEnumerable<int> sizeDistinct = wheels.Where(w => w.Stock > 0).Select(t => t.Size).Distinct();
                IEnumerable<string> pcdsDistinct = wheels.Where(w => w.Stock > 0).Select(t => t.PCD).Distinct();
                IEnumerable<string> wheelsBrands = wheels.Where(w => w.Stock > 0).Select(t => t.Brand).Distinct();

                var sizes = new SelectList(sizeDistinct);
                var pcds = new SelectList(pcdsDistinct);
                var brands = new SelectList(wheelsBrands);

                vm = new SearchWheelViewModel()
                {
                    Sizes = sizes,
                    Brands = brands,
                    PCDs = pcds
                };                
            }
            else
            {
                new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid search");
            }
            return vm;
        }
    }
}
