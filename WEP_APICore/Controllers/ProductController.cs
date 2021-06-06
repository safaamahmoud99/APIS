using BL.AppService;
using BL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEP_APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductAppService _productAppService;

        public ProductController(ProductAppService productAppService)
        {
            this._productAppService = productAppService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_productAppService.GetAllProduct());
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {

            var res = _productAppService.GetProduct(id);
            return Ok(_productAppService.GetProduct(id));
        }
        [HttpGet("LatestArrivals/{numOfProducts}")]
        public IActionResult GetNewLatestProducts(int numOfProducts)
        {
            return Ok(_productAppService.GetLatestProduct(numOfProducts));
        }
        [HttpGet("relatedProducts/{categoryId}/{numberOfProducts}")]
        public IActionResult GetRandomRelatedProducts(int categoryId, int numberOfProducts)
        {
            return Ok(_productAppService.GetRandomRelatedProducts(categoryId, numberOfProducts));
        }
        [HttpGet("category/{catId}/{pageSize}/{pageNumber}")]
        public IActionResult GetProductsByCategoryIdPagination(int catId, int pageSize, int pageNumber)
        {
            return Ok(_productAppService.GetProductsByCategoryIdPagination(catId, pageSize, pageNumber));
        }
        [HttpGet("search/{searchKeyWord}")]
        public IActionResult GetProductsBySearchKeyWord(string searchKeyWord)
        {
            return Ok(_productAppService.GetProductsBySearch(searchKeyWord));
        }
       // [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(ProductViewModel productViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _productAppService.AddNewProduct(productViewModel);

                return Created("CreateProduct", productViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
      //  [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productAppService.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("count")]
        public IActionResult ProductsCount(int categoryId = 0, int colorId = 0)
        {
            return Ok(_productAppService.CountEntity(categoryId, colorId));
        }
        [HttpGet("{pageSize}/{pageNumber}")]
        public IActionResult GetProductsByPage(int pageSize, int pageNumber)
        {
            return Ok(_productAppService.GetPageRecords(pageSize, pageNumber));
        }

    }
}
