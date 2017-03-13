using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;

namespace CarDealer.Services
{
    public class CarsService : Service
    {
        public IEnumerable<CarVm> GetAllCarsByMake(string make)
        {
            var cars = Data.Data.Context
                .Cars
                .Where(c => c.Make.Contains(make))
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance);            

            IEnumerable<CarVm> viewModels = 
                Mapper.Instance.Map<IEnumerable<Car>, IEnumerable<CarVm>>(cars);

            return viewModels;
        }

        public AboutCarVm GetCarWithParts(int id)
        {
            var car = Data.Data.Context.Cars.Find(id);
            IEnumerable<Part> partsOfCar = car.Parts;

            CarVm carVm = Mapper.Map<Car, CarVm>(car);
            IEnumerable<PartVm> partsVm = Mapper.Map<IEnumerable<Part>, IEnumerable<PartVm>>(partsOfCar);

            var viewmodel = new AboutCarVm()
            {
                Car = carVm,
                Parts = partsVm
            };

            return viewmodel;
        }
    }
}
