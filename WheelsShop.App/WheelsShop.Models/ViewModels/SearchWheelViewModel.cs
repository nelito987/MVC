using System.Web.Mvc;

namespace WheelsShop.Models.ViewModels
{
    public class SearchWheelViewModel
    {       

        public SelectList Sizes { get; set; }

        public SelectList Brands { get; set; }

        public SelectList PCDs { get; set; }
    }
}
