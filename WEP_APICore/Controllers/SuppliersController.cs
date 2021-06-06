using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;
using BL.AppService;
using BL.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace WEP_APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly SupplierAppService _supplierAppService;

        public SuppliersController(SupplierAppService supplierAppService)
        {
            _supplierAppService = supplierAppService;
        }

        // GET: api/Suppliers
        [HttpGet]
        public ActionResult<IEnumerable<SupplierViewModel>> Getsuppliers()
        {
            return _supplierAppService.GetAllSuppliers();
           
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public ActionResult<SupplierViewModel> GetSuppliers(int id)
        {
            var suppliers = _supplierAppService.GetSupplier(id);  

            if (suppliers == null)
            {
                return NotFound();
            }

            return suppliers;
        }
      //  [Authorize(Roles = "Admin")]
        // PUT: api/Suppliers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutSuppliers(int id, SupplierViewModel supplierViewModel)
        {
           
            try
            {
                _supplierAppService.UpdateSupplier(supplierViewModel);
                return Ok(supplierViewModel);
            }


            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }
       // [Authorize(Roles = "Admin")]
        // POST: api/Suppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<SupplierViewModel> PostSuppliers(SupplierViewModel supplierViewModel)
        {
            _supplierAppService.CreateSupplier(supplierViewModel);
           

            return CreatedAtAction("GetSuppliers", supplierViewModel);
        }
      //  [Authorize(Roles = "Admin")]
        // DELETE: api/Suppliers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSuppliers(int id)
        {
            var suppliers = _supplierAppService.DeleteSupplier(id);
            return NoContent();
        }

        private bool SuppliersExists(int id)
        {
            return _supplierAppService.CheckSupplierExists(id); 
        }
    }
}
