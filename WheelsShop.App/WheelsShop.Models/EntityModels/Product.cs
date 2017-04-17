﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace WheelsShop.Models.EntityModels
{
    public class Product
    {
        public Product()
        {
            this.ProductSales = new HashSet<Order>();
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
        public int Stock { get; set; }

        //TODO correct file format byte[] or...
        public string ImageUrl { get; set; }

        public virtual ICollection<Order> ProductSales { get; set; }
    }
}
