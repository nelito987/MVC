using System.Collections.Generic;
using System.Web.Mvc;
using CarDealer.Models.ViewModels;
using CarDealer.Services;

namespace CarDealerApp.Controllers
{
    public class SuppliersController: Controller
    {
        private SuppliersService service;


        public SuppliersController()
        {
            this.service = new SuppliersService();
        }

        [HttpGet]
        public ActionResult All(string filter)
        {
            IEnumerable<SupplierVm> viewModels = this.service.GetSuppliersByFilter(filter);
            return this.View(viewModels);
        }
    }
}