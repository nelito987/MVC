using System;
using System.ComponentModel.DataAnnotations;
using WheelsShop.Models.EntityModels.Enums;

namespace WheelsShop.Models.EntityModels
{
    public class Tyre : Product
    {
        public Season Season { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Width must be a positive number")]
        public int Width { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Height must be a positive number")]
        public int Height { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Size must be a positive number")]
        public int Size { get; set; }
    }
}
