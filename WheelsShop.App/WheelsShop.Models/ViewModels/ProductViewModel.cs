using System.ComponentModel.DataAnnotations;
using WheelsShop.Models.EntityModels.Enums;

namespace WheelsShop.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2} BGN")]
        [Range(0, 100000, ErrorMessage = "Price must be a positive number")]
        public decimal Price { get; set; }

        [Range(0, 100000, ErrorMessage = "Stock must be a positive number")]       
        public int Stock { get; set; }

        public Season Season { get; set; }
        
        [Range(0, 100, ErrorMessage = "Size must be a positive number")]
        public int? Size { get; set; }

        [Range(0, 1000, ErrorMessage = "Width must be a positive number")]        
        public int? Width { get; set; }
        
        [Range(0, 100, ErrorMessage = "Height must be a positive number")]
        public int? Height { get; set; }

        public string Description { get; set; }

        public string PCD { get; set; }
        public byte[] ImageUrl { get; set; }
    }
}
