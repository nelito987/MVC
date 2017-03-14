using System.Collections.Generic;
using System.Web.Mvc;
using CarDealer.Models.ViewModels;
using CarDealer.Services;
using CarDealer.Models.BindingModels;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("cars")]
    public class CarsController: Controller
    {
        private CarsService service;


        public CarsController()
        {
            this.service = new CarsService();
        }

        [Route("all")]
        [HttpGet]
        public ActionResult All()
        {
            IEnumerable<CarVm> viewModels = this.service.GetAllCars();
            return this.View(viewModels);
        }

        [Route("{make}")]
        [HttpGet]
        public ActionResult All(string make)
        {
            IEnumerable<CarVm> viewModels = this.service.GetAllCarsByMake(make);
            return this.View(viewModels);
        }

        [HttpGet]
        [Route("{id}/parts/")]
        public ActionResult About(int id)
        {
            AboutCarVm viewModels = this.service.GetCarWithParts(id);
            return this.View(viewModels);
        }

        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {            
            return this.View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(AddCarBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddCarBm(bind);
                return this.RedirectToAction("All");
            }
            return this.View();
        }
    }
}