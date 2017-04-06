using System.Collections.Generic;

namespace WheelsShop.Models.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<OrderViewModel> OrdersVM { get; set; }
    }
}
