 
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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WEP_APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CartProductsController : ControllerBase
    {
        private readonly CartProductAppService _cartProductAppService;
        IHttpContextAccessor _httpContextAccessor;
        private AccountAppService _accountAppservice;
        public CartProductsController(AccountAppService accountAppservice, CartProductAppService cartProductAppService, IHttpContextAccessor httpContextAccessor)
        {
            _cartProductAppService = cartProductAppService;
            _httpContextAccessor = httpContextAccessor;
            _accountAppservice = accountAppservice;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CartProductViewModel>> GetcartProducts(string cartId)
        {
            return _cartProductAppService.GetAllCartProducts(cartId); ;
        }
        [HttpGet("{id}")]
        public ActionResult<CartProductViewModel> GetCartProduct(int id)
        {

            var cartProduct = _cartProductAppService.GetCartProduct(id);
            return cartProduct;
        }
        [HttpPost]
        public ActionResult<CartProduct> PostCartProduct(int productid)
        {
            string username = User.Identity.Name;
            bool found = _cartProductAppService.CheckCartProductExists(productid, username);
            try
            {
                if (found == false)
                {
                    _cartProductAppService.CreateCartProduct(username, productid).Wait();
                    return Ok();
                }
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartProductAsync(int id)
        {
            string username = User.Identity.Name;
            await _cartProductAppService.DeletCartProduct(id, username);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartProductAsync(CartProductViewModel cartProduct)
        {
            // string username = User.Identity.Name;
            string username = "Safaa";
            await _cartProductAppService.UpdateCartProduct(cartProduct, username);

            return NoContent();
        }
        private bool CartProductExists(int id)
        {
            string username = User.Identity.Name;


            return _cartProductAppService.CheckCartProductExists(id, username);
        }
    }
}
 