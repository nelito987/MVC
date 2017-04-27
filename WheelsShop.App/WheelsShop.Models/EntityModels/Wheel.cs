using System.ComponentModel.DataAnnotations;

namespace WheelsShop.Models.EntityModels
{
    public class Wheel: Product
    {
        [Required]
        public string PCD { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Size must be a positive number")]
        //size is not in the Product class, just because there could be more products in the future for which size does not apply
        public int Size { get; set; }
    }
}
