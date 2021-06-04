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
    public class BrandsController : ControllerBase
    {
        private readonly BrandAppService _brandAppService;

        public BrandsController(BrandAppService brandAppService)
        {
            _brandAppService = brandAppService;
        }

        // GET: api/Brands
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<BrandViewModel>> Getbrands()
        {
            return _brandAppService.GetAllBrands();
        }
        [AllowAnonymous]
        // GET: api/Brands/5
        [HttpGet("{id}")]
        public ActionResult<BrandViewModel> GetBrands(int id)
        {
            var brands = _brandAppService.GetBrand(id);

            if (brands == null)
            {
                return NotFound();
            }

            return brands;
        }
        //[Authorize(Roles = "Admin")]
        // PUT: api/Brands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutBrands(int id, BrandViewModel brandViewModel)
        {
           
            try
            {
                _brandAppService.UpdateBrand(brandViewModel);
              
                return Ok(brandViewModel);
            }


            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[Authorize(Roles = "Admin")]
        // POST: api/Brands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<BrandViewModel> PostBrands(BrandViewModel brandViewModel)
        {
            _brandAppService.CreateBrand(brandViewModel);


            return CreatedAtAction("GetBrands", brandViewModel);

        }
        //[Authorize(Roles = "Admin")]
        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBrands(int id)
        {
         
            _brandAppService.DeleteBrand(id);
            

            return NoContent();
        }

        private bool BrandsExists(int id)
        {
            return _brandAppService.CheckBrandExists(id);
           
        }
    }
}
