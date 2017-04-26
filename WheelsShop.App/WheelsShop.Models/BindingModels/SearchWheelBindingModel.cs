using System.ComponentModel.DataAnnotations;

namespace WheelsShop.Models.BindingModels
{
    public class SearchWheelBindingModel
    {
        [Range(0, 100, ErrorMessage = "Size must be a positive number")]
        public int Sizes { get; set; }
        public string Brands { get; set; }

        public string PCDs { get; set; }
    }
}
