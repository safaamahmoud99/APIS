using AutoMapper;
using BL.Bases;
using BL.DTOs;
using BL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppService
{
    public class SupplierAppService : BaseAppService
    {
        public SupplierAppService(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
        public List<SupplierViewModel> GetAllSuppliers()
        {
            return Mapper.Map<List<SupplierViewModel>>(TheUnitOfWork.Supplier.GetAllSuppliesr());
        }
        public SupplierViewModel GetSupplier(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<SupplierViewModel>(TheUnitOfWork.Supplier.GetById(id));
        }
        public bool DeleteSupplier(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.Supplier.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
    }
}
