using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WheelsShop.Models.ViewModels
{
    public class CalculatorViewModel
    {
        [Range(0, 1000, ErrorMessage = "Width must be a positive number")]
        public SelectList Widths { get; set; }

        [Range(0, 1000, ErrorMessage = "Height must be a positive number")]
        public SelectList Height { get; set; }

        [Range(0, 1000, ErrorMessage = "Size must be a positive number")]
        public SelectList Sizes { get; set; }
    }
}
