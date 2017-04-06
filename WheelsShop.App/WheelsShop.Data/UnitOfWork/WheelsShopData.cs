using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WheelsShop.Data.Repositories;
using WheelsShop.Models.EntityModels;

namespace WheelsShop.Data.UnitOfWork
{
    public class WheelsShopData: IWheelsShopData
    {
        private WheelsShopContext dbContext;

        private IDictionary<Type, object> repositories;

        private IUserStore<User> userStore;

        public WheelsShopData()
            : this(new WheelsShopContext())
        {
        }

        public WheelsShopData(WheelsShopContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Product> Products
        {
            get { return this.GetRepository<Product>(); }
        }

        public IRepository<Wheel> Wheels
        {
            get { return this.GetRepository<Wheel>(); }
        }

        public IRepository<Tyre> Tyres
        {
            get { return this.GetRepository<Tyre>(); }
        }

        public IRepository<Order> Sales
        {
            get { return this.GetRepository<Order>(); }
        }

        public IUserStore<User> UserStore
        {
            get
            {
                if (this.userStore == null)
                {
                    this.userStore = new UserStore<User>(this.dbContext);
                }

                return this.userStore;
            }
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EntityFrameworkRepository<T>);
                this.repositories.Add(
                    typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
