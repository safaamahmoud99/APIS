 
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
using Microsoft.AspNetCore.SignalR;
using BL.Hubs;

namespace WEP_APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartProductsController : ControllerBase
    {
        private readonly CartProductAppService _cartProductAppService;
        private IHubContext<SoppingCartWishListHub, ITypedHubClient> _hubContext;
        IHttpContextAccessor _httpContextAccessor;
        private AccountAppService _accountAppservice;
        public CartProductsController
         (
            AccountAppService accountAppservice, 
            CartProductAppService cartProductAppService,
            IHttpContextAccessor httpContextAccessor,
            IHubContext<SoppingCartWishListHub, ITypedHubClient> hubContext
         )
        {
            _cartProductAppService = cartProductAppService;
            _httpContextAccessor = httpContextAccessor;
            _accountAppservice = accountAppservice;
            _hubContext = hubContext;
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
        public async Task<ActionResult<CartProduct>> PostCartProduct(int productid)
        {
            string username = User.Identity.Name;
            bool found =await _cartProductAppService.CheckCartProductExists(productid, username);
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
        [HttpDelete("ClearCart")]
        public async Task<IActionResult> DeleteAllCartProductAsync(string ccartID)
        {
           
            await _cartProductAppService.DeletAllCartProduct(ccartID);

            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCartProductAsync(CartProductViewModel cartProduct)
        {
            string username = User.Identity.Name;
            await _cartProductAppService.UpdateCartProduct(cartProduct, username);
            return NoContent();
        }
        private async Task<bool> CartProductExists(int id)
        {
            string username = User.Identity.Name;


            return await _cartProductAppService.CheckCartProductExists(id, username);
        }
    }
}
 