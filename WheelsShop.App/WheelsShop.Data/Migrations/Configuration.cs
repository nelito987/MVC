using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WheelsShop.Models.EntityModels;
using WheelsShop.Models.EntityModels.Enums;

namespace WheelsShop.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<WheelsShopContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            
        }

        protected override void Seed(WheelsShopContext context)
        {
            //SeedRolesAndUsers(context);
            //SeedTyres(context);
            //SeedWheels(context);
        }

        private void SeedWheels(WheelsShopContext context)
        {
            //var wheels = new List<Wheel>()
            //{
            //    new Wheel()
            //    {
            //        Brand = "OZ",
            //        ImageUrl = "../../Context/Images/botticelli.jpg",
            //        Model = "Botticelli",
            //        PCD = "5X112",
            //        Price = 404,
            //        Size = 17,
            //        Stock = 32
            //    },
            //    new Wheel()
            //    {
            //        Brand = "OZ",
            //        ImageUrl = "../../Context/Images/botticelli.jpg",
            //        Model = "Ultralleggera",
            //        PCD = "5X114",
            //        Price = 436,
            //        Size = 16,
            //        Stock = 22
            //    }
            //};
            //foreach (var wheel in wheels)
            //{
            //    context.Products.Add(wheel);
            //}
            //context.SaveChanges();
        }

        private void SeedTyres(WheelsShopContext context)
        {
            //var tyres = new List<Tyre>()
            //{
            //    new Tyre() {Brand = "Michelin", Width = 195, Height = 65, Size = 15, Model = "Pilot Sport 4", Price = 165, Season = Season.Summer, Stock = 100, ImageUrl = "../../Context/Images/ps4.jpg"},
            //    new Tyre() {Brand = "BF Goodrich", Width = 205, Height = 55, Size = 16, Model = "Winter G-Force", Price = 175, Season = Season.Winter, Stock = 120, ImageUrl = "../../Context/Images/ps4.jpg"},
            //    new Tyre() {Brand = "BF Goodrich", Width = 225, Height = 55, Size = 17, Model = "Winter G-Force", Price = 175, Season = Season.Winter, Stock = 120, ImageUrl = "../../Context/Images/ps4.jpg"},
            //      new Tyre() {Brand = "Michelin", Width = 185, Height = 65, Size = 15, Model = "Pilot Sport 4", Price = 165, Season = Season.Summer, Stock = 100, ImageUrl = "../../Context/Images/ps4.jpg"},
            //    new Tyre() {Brand = "Kormoran", Width = 205, Height = 55, Size = 16, Model = "Runpro", Price = 105, Season = Season.Winter, Stock = 120, ImageUrl = "../../Context/Images/ps4.jpg"},
            //    new Tyre() {Brand = "BF Goodrich", Width = 195, Height = 65, Size = 15, Model = "G-Force", Price = 115, Season = Season.Summer, Stock = 120, ImageUrl = "../../Context/Images/ps4.jpg"}
            //};

            //foreach (var tyre in tyres)
            //{
            //    context.Products.Add(tyre);
            //}
            //context.SaveChanges();
        }


        private static void SeedRolesAndUsers(WheelsShopContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Customer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Customer");

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User() { UserName = "admin", Email = "admin@gmail.com" };

                manager.Create(user, "adminPass123");
                manager.AddToRole(user.Id, "Admin");

                user = new User { UserName = "someUser", Email = "someUser@gmail.com" };
                manager.Create(user, "someUserPass123");


                user = new User() { UserName = "Mika", Email = "mika@gmail.com" };
                manager.Create(user, "Mika123");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "Customer"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User() { UserName = "customer", Email = "customer@gmail.com" };

                manager.Create(user, "customer1");
                manager.AddToRole(user.Id, "Customer");

            }
        }

    }
}
