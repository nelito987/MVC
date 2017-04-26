using System.ComponentModel.DataAnnotations;

namespace WheelsShop.Models.ViewModels
{
    public class TyreViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a positive number")]
        public int Stock;
        public byte[] ImageUrl { get; set; }

        [Display(Name = "Season")]
        public string Season { get; set; }

        [Range(0, 1000, ErrorMessage = "Width must be a positive number")]
        public int Width { get; set; }

        [Range(0, 100, ErrorMessage = "Height must be a positive number")]
        public int Height { get; set; }

        [Range(0, 100, ErrorMessage = "Size must be a natural number")]
        public int Size { get; set; }
    }
}