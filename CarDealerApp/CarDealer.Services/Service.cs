using AutoMapper;
using CarDealer.Data;
using CarDealer.Models.BindingModels;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;
using System.Linq;

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
                    //customer
                    expression.CreateMap<Customer, AllCustomerVm>();
                    expression.CreateMap<Customer, AboutCustomerVm>();
                    expression.CreateMap<AddCustomerBm, Customer>();
                    expression.CreateMap<Customer, EditCustomerVm>();

                    //cars
                    expression.CreateMap<Car, CarVm>();
                    expression.CreateMap<AddCarBm, Car>()
                    .ForMember(c => c.Parts,
                        configurationExpression =>
                        configurationExpression.Ignore());

                    //supplier
                    expression.CreateMap<Supplier, SupplierVm>()
                    .ForMember(vm => vm.PartsCount,
                        configurationExpression =>
                            configurationExpression.MapFrom(supplier => supplier.Parts.Count));
                   
                    //sales
                    expression.CreateMap<Sale, SaleVm>()
                        .ForMember(vm => vm.Price,
                        configurationExpression =>
                        configurationExpression.MapFrom(sale =>
                            sale.Car.Parts.Sum(part => part.Price)));                   

                    //parts
                    expression.CreateMap<AddPartBm, Part>();
                    expression.CreateMap<Part, AllPartsVm>();
                    expression.CreateMap<Part, DeletePartVm>();
                    expression.CreateMap<Part, EditPartVm>();
                    expression.CreateMap<EditPartBm, Part>();
                    expression.CreateMap<Part, PartVm>();
                });
        }
    }
}
