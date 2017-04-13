namespace WheelsShop.Models.BindingModels
{
    public class SearchTyreBindingModel
    {       
        //TODO: only tyres on stock to be in the drop down
        public int Widths { get; set; }

        public int Height { get; set; }
        public int Sizes { get; set; }
        public string Brands { get; set; }

        public string Seasons { get; set; }

        //TODO: public string Order { get; set; }
    }
}