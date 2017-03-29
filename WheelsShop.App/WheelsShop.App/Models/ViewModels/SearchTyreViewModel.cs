using System.Collections.Generic;
using System.Web.Mvc;

namespace WheelsShop.App.Models.ViewModels
{
    public class SearchTyreViewModel
    {
        public IEnumerable<SelectListItem> Widths { get; set; }

        public IEnumerable<SelectListItem> Height { get; set; }

        public IEnumerable<SelectListItem> Sizes { get; set; }

        public IEnumerable<SelectListItem> Brands { get; set; }

        public IEnumerable<SelectListItem> Seasons { get; set; }
    }
}