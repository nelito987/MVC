using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;

namespace CarDealer.Services
{
    public class CustomersService: Service
    {
        public IEnumerable<AllCustomerVm> GetAllOrderedCustomers(string order)
        {
            IEnumerable<Customer> customers;
            if (order == "ascending")
            {
                customers = Data.Data.Context.Customers
                    .OrderBy(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver);
            }
            else if (order == "descending")
            {
                customers = Data.Data.Context.Customers
                    .OrderByDescending(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver);
            }
            else
            {
                throw new ArgumentException("Argument is not valid");
            }

            IEnumerable<AllCustomerVm> viewModels =
                Mapper.Instance.Map<IEnumerable<Customer>, IEnumerable<AllCustomerVm>>(customers);

            return viewModels;
        }

        //public AboutCustomerVm GetCustomerWithCarData(int id)
        //{
        //    //Customer customer = Data.Data.Context.Customers.Find(id);
        //    //return new AboutCustomerVm()
        //    //{

        //    //}
        //}

        
    }
}
