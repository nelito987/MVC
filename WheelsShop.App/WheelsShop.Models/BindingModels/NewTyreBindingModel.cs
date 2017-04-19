using System.ComponentModel.DataAnnotations;
using System.Web;
using WheelsShop.Models.EntityModels.Enums;

namespace WheelsShop.Models.BindingModels
{
    public class NewTyreBindingModel
    {
        [Required(ErrorMessage = "The {0} is required!")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Width must be a natural number")]
        public int Width { get; set; }

        [Required(ErrorMessage = "The {0} is required!")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Height must be a natural number")]
        public int Height { get; set; }

        [Required(ErrorMessage = "The {0} is required!")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Size must be a natural number")]
        public int Size { get; set; }


        [Required(ErrorMessage = "The {0} is required!")]
        public string Brand { get; set; }

        [Display(Name = "Season", ResourceType = typeof(Season))]
        public string Season { get; set; }
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
        public HttpPostedFileBase ImageUrl { get; set; }
    }
}
