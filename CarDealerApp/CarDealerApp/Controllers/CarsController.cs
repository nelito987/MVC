﻿using System.Collections.Generic;
using System.Web.Mvc;
using CarDealer.Models.ViewModels;
using CarDealer.Services;

namespace CarDealerApp.Controllers
{
    public class CarsController: Controller
    {
        private CarsService service;


        public CarsController()
        {
            this.service = new CarsService();
        }

        [HttpGet]
        public ActionResult All(string make)
        {
            IEnumerable<CarVm> viewModels = this.service.GetAllCarsByMake(make);
            return this.View(viewModels);
        }

        [HttpGet]
        [Route("cars/{id}/parts/")]
        public ActionResult About(int id)
        {
            AboutCarVm viewModels = this.service.GetCarWithParts(id);
            return this.View(viewModels);
        }
    }
}