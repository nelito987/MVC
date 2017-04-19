namespace WheelsShop.Models.ViewModels
{
    public class WheelViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }

        public int Stock;
        public byte[] ImageUrl { get; set; }

        public string PCD { get; set; }
        public int Size { get; set; }
    }
}
