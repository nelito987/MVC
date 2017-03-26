using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WheelsShop.Models.EntityModels
{
    public class User: IdentityUser
    {
        public User()
        {
            this.ProductsBought = new HashSet<Sale>();
        }

        public virtual ICollection<Sale> ProductsBought { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

       
    }
}
