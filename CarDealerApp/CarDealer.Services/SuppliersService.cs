using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;

namespace CarDealer.Services
{
    public class SuppliersService: Service
    {
        public IEnumerable<SupplierVm> GetSuppliersByFilter(string filter)
        {
            IEnumerable<Supplier> suppliers;
            if (filter.ToLower() == "local")
            {
                suppliers = Data.Data.Context.Suppliers
                    .Where(s => s.IsImporter == true);
            }
            else if (filter.ToLower() == "importer")
            {
                suppliers = Data.Data.Context.Suppliers
                    .Where(s => s.IsImporter == false);
            }
            else
            {
                throw new ArgumentException("Invalid argument for supplier");
            }

            IEnumerable<SupplierVm> viewModels = 
                Mapper.Instance.Map<IEnumerable<Supplier>, IEnumerable<SupplierVm>>(suppliers);

            return viewModels;

        }
    }
}
