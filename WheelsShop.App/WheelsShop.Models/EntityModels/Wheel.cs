using System.ComponentModel.DataAnnotations;

namespace WheelsShop.Models.EntityModels
{
    public class Wheel: Product
    {
        [Required]
        public string PCD { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Size must be a positive number")]
        public double Size { get; set; }
    }
}
