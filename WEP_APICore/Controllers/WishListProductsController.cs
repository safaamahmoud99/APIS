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

namespace WEP_APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListProductsController : ControllerBase
    {
        private readonly WishListProductAppService _wishListProductAppService;

        public WishListProductsController(WishListProductAppService wishListProductAppService)
        {
            _wishListProductAppService= wishListProductAppService;
        }

        // GET: api/WishListProducts
        [HttpGet]
        public ActionResult<IEnumerable<WishListProductViewModel>> GetwishListProducts()
        {
            return _wishListProductAppService.GetAllWishListProducts();
        }

        // GET: api/WishListProducts/5
        [HttpGet("{id}")]
        public ActionResult<WishListProductViewModel> GetWishListProduct(int id)
        {

            var wishListProduct =_wishListProductAppService.GetWishListProduct(id);
            return wishListProduct;
        }

        // PUT: api/WishListProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    

        // POST: api/WishListProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<WishListProductViewModel> PostWishListProduct(int id)
        {
            string username = User.Identity.Name;

           

            try
            {
                if(!_wishListProductAppService.CheckWishListProductExists(id))
                {
                    _wishListProductAppService.CreateWishListProduct(username, id);

                    return Ok();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // DELETE: api/WishListProducts/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWishListProduct(int id)
        {
            _wishListProductAppService.DeletWishListProduct(id);

            return NoContent();
        }

       public bool WishListProductExists(int id)
        {
            return _wishListProductAppService.CheckWishListProductExists(id);
        }
    }
}
