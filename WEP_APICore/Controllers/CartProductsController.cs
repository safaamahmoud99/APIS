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
    public class CartProductsController : ControllerBase
    {
        private readonly CartProductAppService _cartProductAppService;

        public CartProductsController(CartProductAppService cartProductAppService)
        {
            _cartProductAppService = cartProductAppService;
        }

        // GET: api/CartProducts
        [HttpGet]
        public ActionResult<IEnumerable<CartProductViewModel>> GetcartProducts()
        {
            return _cartProductAppService.GetAllCartProducts(); ;
        }

        // GET: api/CartProducts/5
        [HttpGet("{id}")]
        public ActionResult<CartProductViewModel> GetCartProduct(int id)
        {

            var cartProduct = _cartProductAppService.GetCartProduct(id);
            return cartProduct;
        }

       

        // POST: api/CartProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<CartProduct> PostCartProduct(int productid)
        {
            string username = User.Identity.Name;



            try
            {
                if(!_cartProductAppService.CheckCartProductExists(productid))
                {
                    _cartProductAppService.CreateCartProduct(username, productid);
                    return Ok();
                }
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // DELETE: api/CartProducts/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCartProduct(int id)
        {
            _cartProductAppService.DeletCartProduct(id);

            return NoContent();
        }

        private bool CartProductExists(int id)
        {
            return _cartProductAppService.CheckCartProductExists(id);
        }
    }
}
