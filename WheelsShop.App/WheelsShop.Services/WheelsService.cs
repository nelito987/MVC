using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var wheels = this.Data.Products.Where(p => p is Wheel).ToList();
            var wheelsVm = Mapper.Map<IEnumerable<WheelViewModel>>(wheels);
            return wheelsVm;
        }

        public IEnumerable<WheelViewModel> GetSearchWheelInfo(SearchWheelBindingModel model)
        {
            var wheels = this.Data.Products.All().OfType<Wheel>();

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

            var wheelsVm = Mapper.Map<IEnumerable<WheelViewModel>>(wheels);
            return wheelsVm;
        }

        public SearchWheelViewModel LoadDataToViewBag(IEnumerable<WheelViewModel> wheels)
        {
            //TODO change double to int
            IEnumerable<int> sizeDistinct = wheels.Select(t => t.Size).Distinct();
            IEnumerable<string> pcdsDistinct = wheels.Select(t => t.PCD).Distinct();
            IEnumerable<string> wheelsBrands = wheels.Select(t => t.Brand).Distinct();
            //List<string> orders = new List<string>() { "Price", "Brand", "Size" };

            var sizes = new SelectList(sizeDistinct);
            var pcds = new SelectList(pcdsDistinct);
            var brands = new SelectList(wheelsBrands);

            var vm = new SearchWheelViewModel()
            {
                Sizes = sizes,                
                Brands = brands,
                PCDs = pcds
            };

            return vm;
        }
    }
}
