using AutoMapper;
using CarDealer.Data;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;

namespace CarDealer.Services
{
    public abstract class Service
    {
        protected CarDealerContext context;

        protected Service()
        {
            ConfigureMapper();
        }

        protected void ConfigureMapper()
        {
            Mapper.Initialize(
                expression =>
                {
                    expression.CreateMap<Customer, AllCustomerVm>();
                    expression.CreateMap<Car, CarVm>();
                    expression.CreateMap<Supplier, SupplierVm>();
                });
        }
    }
}
