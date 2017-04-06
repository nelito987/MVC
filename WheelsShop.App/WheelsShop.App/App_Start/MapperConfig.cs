using AutoMapper;
using WheelsShop.Models.ViewModels;
using WheelsShop.Models.EntityModels;

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
            });
        }
    }
}