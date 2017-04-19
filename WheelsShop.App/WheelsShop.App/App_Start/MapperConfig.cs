using System.Collections.Generic;
using AutoMapper;
using WheelsShop.Models.ViewModels;
using WheelsShop.Models.EntityModels;
using WheelsShop.Models.BindingModels;
using System.Web;

namespace WheelsShop.App.App_Start
{
    public static class MapperConfig
    {
        public static void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
            {                
                expression.CreateMap<Tyre, TyreViewModel>();
                expression.CreateMap<Wheel, WheelViewModel>();
                //expression.CreateMap<TyreViewModel, Tyre>();//TODO <- delete
                //expression.CreateMap<Product, ProductViewModel>()
                //    .ForMember<Tyre>(pvm => pvm.Size, p => p.MapFrom(t => t.))

                expression.CreateMap<Tyre, ProductViewModel>()
                    .ForMember(pvm => pvm.Size, p => p.MapFrom(t => t.Size))
                    .ForMember(pvm => pvm.Height, p => p.MapFrom(t => t.Height))
                    .ForMember(pvm => pvm.Width, p => p.MapFrom(t => t.Width));
                expression.CreateMap<Wheel, ProductViewModel>()
                    .ForMember(pvm => pvm.Size, p => p.MapFrom(t => t.Size))
                    .ForMember(pvm => pvm.PCD, p => p.MapFrom(w => w.PCD));

                expression.CreateMap<EditProductBindingModel, Product>();
                expression.CreateMap<Order, OrderViewModel>();
                expression.CreateMap<NewTyreBindingModel, Tyre>().ForMember(t => t.ImageUrl, tv => tv.Ignore());                    
                expression.CreateMap<NewWheelBindingModel, Wheel>().ForMember(t => t.ImageUrl, tv => tv.Ignore());
                expression.CreateMap<User, UserViewModel>();
            });
        }
    }
}