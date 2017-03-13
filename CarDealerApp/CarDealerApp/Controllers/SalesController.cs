using CarDealer.Models.ViewModels;
using CarDealer.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("sales")]
    public class SalesController : Controller
    {
        private SalesService service;

        public SalesController()
        {
            this.service = new SalesService();
        }

        [HttpGet]
        [Route]
        public ActionResult All()
        {
            IEnumerable<SaleVm> viewModels = this.service.GetAllSales();
            return this.View(viewModels);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult Details(int id)
        {
           SaleVm viewModels = this.service.GetSaleDetails(id);
            return this.View(viewModels);
        }

        [HttpGet]
        [Route("discounted/{percent?}/")]
        public ActionResult Discounted(double? percent)
        {
            IEnumerable<SaleVm> viewModels = this.service.GetDiscountedSales(percent);
            return this.View(viewModels);
        }
    }
}