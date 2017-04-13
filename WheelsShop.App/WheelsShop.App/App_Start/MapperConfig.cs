using System.Collections.Generic;
using AutoMapper;
using WheelsShop.Models.ViewModels;
using WheelsShop.Models.EntityModels;
using WheelsShop.Models.BindingModels;

namespace WheelsShop.App.App_Start
{
    public static class MapperConfig
    {
        public static void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Tyre, TyreViewModel>();
                expression.CreateMap<TyreViewModel, Tyre>();
                //expression.CreateMap<Product, ProductViewModel>()
                //    .ForMember<Tyre>(pvm => pvm.Size, p => p.MapFrom(t => t.))

                expression.CreateMap<Tyre, ProductViewModel>()
                    .ForMember(pvm => pvm.Size, p => p.MapFrom(t => t.Size))
                    .ForMember(pvm => pvm.Height, p => p.MapFrom(t => t.Height))
                    .ForMember(pvm => pvm.Width, p => p.MapFrom(t => t.Width));
                expression.CreateMap<Wheel, ProductViewModel>()
                    .ForMember(pvm => pvm.Size, p => p.MapFrom(t => t.Size))
                    .ForMember(pvm => pvm.PCD, p => p.MapFrom(w => w.PCD));

                expression.CreateMap<Order, OrderViewModel>();

                expression.CreateMap<NewTyreBindingModel, Tyre>();
            });
        }
    }
}