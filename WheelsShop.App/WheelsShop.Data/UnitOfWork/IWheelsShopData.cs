using WheelsShop.Data.Repositories;
using WheelsShop.Models.EntityModels;

namespace WheelsShop.Data.UnitOfWork
{
    public interface IWheelsShopData
    {
        IRepository<User> Users { get; }
        IRepository<Product> Products { get; }

        //IRepository<Wheel> Wheels { get; }
        //IRepository<Tyre> Tyres { get; }
        IRepository<Order> Sales { get; }

        void SaveChanges();

        //TODO do I need IRepository<Product>
    }
}
