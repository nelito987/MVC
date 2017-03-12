namespace CarDealer.Data
{
    public class Data
    {
        private static CarDealerContext context;

        public static CarDealerContext Context
        {
            get
            {
                return context ?? (context = new CarDealerContext());
            }
        }
    }
}
