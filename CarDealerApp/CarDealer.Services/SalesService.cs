using System.Collections.Generic;
using CarDealer.Models.ViewModels;
using CarDealer.Models.EntityModels;
using AutoMapper;
using System.Linq;

namespace CarDealer.Services
{
    public class SalesService : Service
    {
        public IEnumerable<SaleVm> GetAllSales()
        {
            IEnumerable<Sale> sales = Data.Data.Context.Sales;

            IEnumerable<SaleVm> vm = Mapper.Map<IEnumerable<Sale>, IEnumerable<SaleVm>>(sales);
            return vm;
        }

        public SaleVm GetSaleDetails(int id)
        {
            Sale sale = Data.Data.Context.Sales.Find(id);
            SaleVm vm = Mapper.Map<Sale, SaleVm>(sale);
            return vm;
        }

        public IEnumerable<SaleVm> GetDiscountedSales(double? percent)
        {
            percent /= 100;
            IEnumerable<Sale> sales = Data.Data.Context.Sales.Where(sale => sale.Discount != 0);

            if (percent != null)
            {
                sales = sales.Where(sale => sale.Discount == percent.Value);
            }

            IEnumerable<SaleVm> vms = Mapper.Map<IEnumerable<Sale>, IEnumerable<SaleVm>>(sales);
            return vms;
        }
    }
}
