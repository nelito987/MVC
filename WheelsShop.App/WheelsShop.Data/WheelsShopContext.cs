using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WheelsShop.Models.EntityModels;

namespace WheelsShop.Data
{
    public class WheelsShopContext : IdentityDbContext<User>
    {
        public WheelsShopContext()
            : base("WheelsShopConnection", throwIfV1Schema: false)
        {
        }

        public static WheelsShopContext Create()
        {
            return new WheelsShopContext();
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tyre>().ToTable("Tyres");
            modelBuilder.Entity<Wheel>().ToTable("Wheels");
            //later
            //modelBuilder.Entity<Game>()
            //    .HasMany(g => g.Ratings)
            //    .WithRequired(r => r.Game)
            //    .WillCascadeOnDelete(false);
            //modelBuilder.Entity<Game>()
            //    .HasMany(g => g.Reviews)
            //    .WithRequired(r => r.Game)
            //    .WillCascadeOnDelete(false);
            //base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }        
    }

}