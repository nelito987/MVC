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
                    expression.CreateMap<Customer, AllCustomerVm>();
                    expression.CreateMap<Customer, AboutCustomerVm>();
                    expression.CreateMap<Car, CarVm>();
                    expression.CreateMap<Supplier, SupplierVm>()
                    .ForMember(vm => vm.PartsCount,
                        configurationExpression =>
                            configurationExpression.MapFrom(supplier => supplier.Parts.Count));
                    expression.CreateMap<Part, PartVm>();
                    expression.CreateMap<Sale, SaleVm>()
                        .ForMember(vm => vm.Price,
                        configurationExpression =>
                        configurationExpression.MapFrom(sale =>
                            sale.Car.Parts.Sum(part => part.Price)));

                    expression.CreateMap<AddCustomerBm, Customer>();
                    expression.CreateMap<Customer, EditCustomerVm>();

                    expression.CreateMap<AddPartBm, Part>();
                    expression.CreateMap<Part, AllPartsVm>();
                    expression.CreateMap<Part, DeletePartVm>();
                    expression.CreateMap<Part, EditPartVm>();
                    expression.CreateMap<EditPartBm, Part>();
                });
        }
    }
}
