using System.ComponentModel.DataAnnotations;

namespace WheelsShop.Models.ViewModels
{
    public class WheelViewModel
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
        
        [Range(0, 100, ErrorMessage = "Size must be a natural number")]
        public int Size { get; set; }   
        public string PCD { get; set; }
    }
}
