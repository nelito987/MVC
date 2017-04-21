using System.Web.Mvc;
using WheelsShop.Data.UnitOfWork;

namespace WheelsShop.App.Controllers
{
    public abstract class BaseController : Controller
    {       
        protected BaseController(IWheelsShopData data)
        {
            this.Data = data;
        }

        protected IWheelsShopData Data { get; private set; }
    }
}