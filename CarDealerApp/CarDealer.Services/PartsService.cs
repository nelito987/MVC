using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealer.Models.BindingModels;
using CarDealer.Models.EntityModels;
using AutoMapper;
using CarDealer.Models.ViewModels;

namespace CarDealer.Services
{
    public class PartsService : Service
    {
        public void AddPartBm(AddPartBm bind)
        {
            Part part = Mapper.Map<AddPartBm, Part>(bind);
            Supplier supplier = Data.Data.Context.Suppliers.Find(bind.SupplierId);
            part.Supplier = supplier;
            if (part.Quantity == 0)
            {
                part.Quantity = 1;
            }

            Data.Data.Context.Parts.Add(part);
            Data.Data.Context.SaveChanges();
        }

        public IEnumerable<AddPartSupplierVm> GetAddVm()
        {
            return Data.Data.Context.Suppliers.Select(supplier => new AddPartSupplierVm()
            {
                Id = supplier.Id,
                Name = supplier.Name
            });
        }

        public IEnumerable<AllPartsVm> GetAllPartVms()
        {
            IEnumerable<Part> parts = Data.Data.Context.Parts;
            IEnumerable<AllPartsVm> vms = Mapper.Map<IEnumerable<Part>, IEnumerable<AllPartsVm>>(parts);
            return vms;
        }

        public DeletePartVm GetDeleteVm(int id)
        {
            Part part = Data.Data.Context.Parts.Find(id);
            return Mapper.Map<Part, DeletePartVm>(part);
        }

        public void DeletePart(DeletePartBm bind)
        {
            Part part = Data.Data.Context.Parts.Find(bind.PartId);
            Data.Data.Context.Parts.Remove(part);
            Data.Data.Context.SaveChanges();
        }

        public EditPartVm GetEditVm(int id)
        {
            Part part = Data.Data.Context.Parts.Find(id);
            return Mapper.Map<Part, EditPartVm>(part);
        }

        public void EditPart(EditPartBm bind)
        {
            Part part = Data.Data.Context.Parts.Find(bind.Id);
            if (part == null)
            {
                throw new ArgumentException("Cannot find such part!");
            }

            part.Name = bind.Name;
            part.Price = bind.Price;
            part.Quantity = bind.Quantity;
            Data.Data.Context.SaveChanges();
        }
    }
}
