﻿namespace WheelsShop.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public int? Size { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }

        public string PCD { get; set; }
        public string ImageUrl { get; set; }
    }
}
