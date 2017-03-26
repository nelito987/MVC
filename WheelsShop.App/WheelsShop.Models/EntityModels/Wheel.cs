using System.ComponentModel.DataAnnotations;

namespace WheelsShop.Models.EntityModels
{
    public class Wheel: Product
    {
        [Required]
        public string PCD { get; set; }

        [Required]
        public double Size { get; set; }
    }
}
