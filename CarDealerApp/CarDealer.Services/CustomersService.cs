using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Models.BindingModels;
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

        public AboutCustomerVm GetCustomerById(int id)
        {
            Customer customer = Data.Data.Context.Customers.Find(id);
            var viewModel = new AboutCustomerVm()
            {
                Name = customer.Name,
                BoughtCarsCount = customer.Sales.Count,
                TotalSpentMoney = customer.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))
            };

            return viewModel;
        }

        public void AddCustomerBm(AddCustomerBm bind)
        {
            Customer customer = Mapper.Map<AddCustomerBm, Customer>(bind);
            if(DateTime.Now.Year - bind.BirthDate.Year < 21)
            {
                customer.IsYoungDriver = true;
            }
            Data.Data.Context.Customers.Add(customer);
            Data.Data.Context.SaveChanges();
        }

        public EditCustomerVm GetEditVm(int id)
        {
            Customer customer = Data.Data.Context.Customers.Find(id);
            EditCustomerVm vm = Mapper.Map<Customer, EditCustomerVm>(customer);
            return vm;
        }

        public void EditCustomer(EditCustomerBm bind)
        {
            Customer editedCustomer = Data.Data.Context.Customers.Find(bind.Id);
            if (editedCustomer == null)
            {
                throw new ArgumentException("Cannot such customer!");
            }

            editedCustomer.Name = bind.Name;
            editedCustomer.BirthDate = bind.BirthDate;
            Data.Data.Context.SaveChanges();
        }
    }
}
