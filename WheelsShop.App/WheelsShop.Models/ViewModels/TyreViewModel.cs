﻿using System.ComponentModel.DataAnnotations;

namespace WheelsShop.Models.ViewModels
{
    public class TyreViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        public int Stock;
        public byte[] ImageUrl { get; set; }

        [Display(Name = "Season")]
        public string Season { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
        public int Size { get; set; }
    }
}