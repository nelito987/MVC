using System.ComponentModel.DataAnnotations;

namespace WheelsShop.Models.BindingModels
{
    public class SearchTyreBindingModel
    {
        //TODO: only tyres on stock to be in the drop down        
        [Range(0, 100, ErrorMessage = "Width must be a positive number")]
        public int Widths { get; set; }

        [Range(0, 1000, ErrorMessage = "Height must be a positive number")]
        public int Height { get; set; }

        [Range(0, 100, ErrorMessage = "Size must be a positive number")]
        public int Sizes { get; set; }
        public string Brands { get; set; }

        public string Seasons { get; set; }        
    }
}