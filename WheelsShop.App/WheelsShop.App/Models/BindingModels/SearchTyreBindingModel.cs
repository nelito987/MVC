using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WheelsShop.App.Models.BindingModels
{
    public class SearchTyreBindingModel
    {       
        public int Widths { get; set; }

        public int Height { get; set; }
        public int Sizes { get; set; }
        public string Brands { get; set; }

        public string Seasons { get; set; }
    }
}