namespace WheelsShop.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        
        public string Brand { get; set; }
       
        public string Model { get; set; }
       
        public decimal Price { get; set; }
      
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
    }
}
