using AutoMapper;
using BL.Bases;
using BL.DTOs;
using BL.interfaces;
using DAL.Models;
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
            return Mapper.Map<List<SupplierViewModel>>(TheUnitOfWork.Supplier.GetAllSupplier());
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
        public bool CreateSupplier(SupplierViewModel supplierViewModel)
        {
            if (supplierViewModel == null)

                throw new ArgumentNullException();



            bool result = false;
            var supplier = Mapper.Map<Suppliers>(supplierViewModel);
            if (TheUnitOfWork.Supplier.Insert(supplier))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool CheckSupplierExists(int supplierId)
        {
            var result = TheUnitOfWork.Supplier.CheckSupplierExists(supplierId);

            if (result)
            {
                return true;
            }
            return false;
        }

        public bool UpdateSupplier(SupplierViewModel supplierViewModel)
        {
            var supplier = Mapper.Map<Suppliers>(supplierViewModel);
            TheUnitOfWork.Supplier.Update(supplier); 
            TheUnitOfWork.Commit();

            return true;
        }
        public int CountEntity()
        {
            return TheUnitOfWork.Supplier.CountEntity();
        }
        public IEnumerable<SupplierViewModel> GetPageRecords(int pageSize, int pageNumber)
        {
            return Mapper.Map<List<SupplierViewModel>>(TheUnitOfWork.Supplier.GetPageRecords(pageSize, pageNumber));
        }
    }
}
