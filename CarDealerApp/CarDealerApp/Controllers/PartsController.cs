using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models.EntityModels;
using CarDealer.Services;
using CarDealer.Models.BindingModels;
using CarDealer.Models.ViewModels;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("parts")]
    public class PartsController : Controller
    {
        private PartsService service;

        public PartsController()
        {
            this.service = new PartsService();
        }

        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            var vms = this.service.GetAddVm();
            return this.View(vms);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include = "Name, Price, Quantity, SupplierId")] AddPartBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddPartBm(bind);
                return this.RedirectToAction("All");
            }

            var vms = this.service.GetAddVm();
            return this.View(vms);
        }

        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            IEnumerable<AllPartsVm> vms = this.service.GetAllPartVms();
            return this.View(vms);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            DeletePartVm vm = this.service.GetDeleteVm(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public ActionResult Delete([Bind(Include = "PartId")] DeletePartBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.DeletePart(bind);
                return this.RedirectToAction("All");
            }

            var vms = this.service.GetDeleteVm(bind.PartId);
            return this.View(vms);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            EditPartVm vm = this.service.GetEditVm(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("edit/{id}")]
        public ActionResult Edit([Bind(Include = "Id, Name, Price, Quantity ")] EditPartBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditPart(bind);
                return this.RedirectToAction("All");
            }

            var vms = this.service.GetEditVm(bind.Id);
            return this.View(vms);
        }

    }
}
