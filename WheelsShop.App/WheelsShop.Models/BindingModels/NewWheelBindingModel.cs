using System.ComponentModel.DataAnnotations;
using WheelsShop.Models.EntityModels.Enums;

namespace WheelsShop.Models.BindingModels
{
    public class NewWheelBindingModel
    {
        [Required(ErrorMessage = "The {0} is required!")]
        public string PCD { get; set; }

        [Required(ErrorMessage = "The {0} is required!")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Size must be a natural number")]
        public int Size { get; set; }


        [Required(ErrorMessage = "The {0} is required!")]
        public string Brand { get; set; }
        
        [Required(ErrorMessage = "The {0} is required!")]
        public string Model { get; set; }

        [Required(ErrorMessage = "The {0} is required!")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Quantity must be a positive number")]
        [Display(Name = "Quantity")]
        public int? Stock { get; set; }

        [Display(Name = "Image")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
    }
}
