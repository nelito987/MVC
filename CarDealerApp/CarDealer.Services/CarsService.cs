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

            //IEnumerable<AllCustomerVm> viewModels =
            //    Mapper.Instance.Map<IEnumerable<Customer>, IEnumerable<AllCustomerVm>>(customers);

            IEnumerable<CarVm> viewModels = 
                Mapper.Instance.Map<IEnumerable<Car>, IEnumerable<CarVm>>(cars);

            return viewModels;
        }
    }
}
