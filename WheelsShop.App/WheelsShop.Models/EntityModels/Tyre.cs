using System;
using System.ComponentModel.DataAnnotations;
using WheelsShop.Models.EntityModels.Enums;

namespace WheelsShop.Models.EntityModels
{
    public class Tyre : Product
    {
        public Season Season { get; set; }

        [Required]
        public int Width { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public int Size { get; set; }
    }
}
