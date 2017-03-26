using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace WheelsShop.Models.EntityModels
{
    public class Product
    {
        public Product()
        {
            this.ProductSales = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock;
        public string ImageUrl { get; set; }

        public virtual ICollection<Sale> ProductSales { get; set; }
    }
}
