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
        [HttpGet("AllProductDevices")]
        public IActionResult GetAllProductDevices()
        {
            return Ok(_productAppService.GetAllProductDevices());
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult PutProduct(int id, ProductViewModel productViewModel)
        {
            try
            {
                _productAppService.UpdateProduct(productViewModel);
                return Ok(productViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<ProductViewModel> GetProductById(int id)
        {

            var res = _productAppService.GetProduct(id);
            return Ok(_productAppService.GetProduct(id));
        }
        [HttpGet("AllProductBySubCategoryId")]
        public ActionResult<ProductViewModel> GetProductBySubCategoryId(int id)
        {
            return Ok(_productAppService.GetAllProductInASpecificSubCategory(id));
        }
        [HttpGet("AllProductsBetweenTwoPrice")]
        public ActionResult<ProductViewModel> GetAllProductBetweenTwoPrice(int id,double min_price, double max_price)
        {
            return Ok(_productAppService.GetAllProductBetweenTwoPrice(id,min_price, max_price));
        }
        [HttpGet("AllProductsInAspecificBrand")]
        public ActionResult<ProductViewModel> AllProductsInAspecificBrand(int subcategoryid,int brandid)
        {
            return Ok(_productAppService.GetAllProductInAspecificBrands(subcategoryid,brandid));
        }
        [HttpGet("GetAllProductfilteredBySize")]
        public ActionResult<ProductViewModel> GetAllProductfilteredBySize(int subcategoryid, string size)
        {
            return Ok(_productAppService.GetAllProductfilteredBySize(subcategoryid, size));
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
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateProduct")]
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
        [Authorize(Roles = "Admin")]
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
        public IActionResult ProductsCount()
        {
            return Ok(_productAppService.CountEntity());
        }
        [HttpGet("{pageSize}/{pageNumber}")]
        public IActionResult GetProductsByPage(int pageSize, int pageNumber)
        {
            return Ok(_productAppService.GetPageRecords(pageSize, pageNumber));
        }
        [HttpGet("GetAllProductfilteredByCategoryID")]
        public ActionResult<ProductViewModel> GetAllProductfilteredByCategoryID(int id)
        {
            return Ok(_productAppService.GetAllProductfilteredByCategoryID(id));
        }
        [HttpGet("GetAllProductFilteredByBrandID")]
        public ActionResult<ProductViewModel> GetAllProductFilteredByBrandID(int id)
        {
            return Ok(_productAppService.GetAllProductFilteredByBrandID(id));
        }
        [HttpGet("GetAllProductFilteredBySizeonly")]
        public ActionResult<ProductViewModel> GetAllProductFilteredBySizeonly(string size)
        {
            return Ok(_productAppService.GetAllProductFilteredBySizeonly(size));
        }
        [HttpGet("GetAllProductFilteredByColor")]
        public ActionResult<ProductViewModel> GetAllProductFilteredByColor(string color)
        {
            return Ok(_productAppService.GetAllProductFilteredByColor(color));
        }
        [HttpGet("GetAllProductFilteredByMainCategory")]
        public ActionResult<ProductViewModel> GetAllProductFilteredByMainCategory(int id)
        {
            return Ok(_productAppService.GetAllProductFilteredByMainCategory(id));
        }
        [HttpGet("GetAllProductCountinSubCategory")]
        public int GetAllProductCountinSubCategory(int id)
        {
            return _productAppService.GetAllProductCountinSubCategory(id);
        }
        [HttpGet("GetAllProductFilteredByPrice")]
        public IActionResult GetAllProductFilteredByPrice(double min_price,double max_price)
        {
            return Ok(_productAppService.GetAllProductFilteredByPrice(min_price,max_price));
        }

        [HttpGet("GetAllProductFilteredBySupplier")]
        public IActionResult GetAllProductFilteredBysupplier(int supplierId)
        {
            return Ok(_productAppService.GetAllProductFilteredBysupplier(supplierId));
        }
        [HttpPut("PutDiscount")]
        [Authorize(Roles = "Admin")]
        public IActionResult PutDiscount(int idProduct,double Discount)
        {
            try
            {
                _productAppService.UpdateDiscount(idProduct,Discount);
                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
