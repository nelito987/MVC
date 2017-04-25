using System.Web.Mvc;

namespace WheelsShop.App.Areas.Neli
{
    public class NeliAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Neli";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "Neli_default",
                "Neli/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}