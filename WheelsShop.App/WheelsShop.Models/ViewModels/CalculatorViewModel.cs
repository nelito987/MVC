using System.Web.Mvc;

namespace WheelsShop.Models.ViewModels
{
    public class CalculatorViewModel
    {
        public SelectList Widths { get; set; }

        public SelectList Height { get; set; }

        public SelectList Sizes { get; set; }
    }
}
