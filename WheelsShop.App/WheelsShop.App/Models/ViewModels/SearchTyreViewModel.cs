using System.Collections.Generic;
using System.Web.Mvc;

namespace WheelsShop.App.Models.ViewModels
{
    public class SearchTyreViewModel
    {
        public int WidthId { get; set; }
        public SelectList Widths { get; set; }

        public int HeightId { get; set; }

        public SelectList Height { get; set; }

        public int SizeId { get; set; }
        public SelectList Sizes { get; set; }

        public int BrandId { get; set; }
        public SelectList Brands { get; set; }
        public int SeasonId { get; set; }

        public SelectList Seasons { get; set; }
    }
}