using System.Collections.Generic;
using System.Web.Mvc;

namespace WheelsShop.Models.ViewModels
{
    public class SearchTyreViewModel
    {
        public SelectList Widths { get; set; }

        public SelectList Height { get; set; }
        
        public SelectList Sizes { get; set; }
        
        public SelectList Brands { get; set; }

        public SelectList Seasons { get; set; }

       // public SelectList Order { get; set; }
        
    }
}