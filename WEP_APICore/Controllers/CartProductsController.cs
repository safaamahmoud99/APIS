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
        [HttpGet]
        public ActionResult<IEnumerable<CartProductViewModel>> GetcartProducts()
        {
            return _cartProductAppService.GetAllCartProducts(); ;
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
            // string username = User.Identity.Name;

            string username = "Asd";
            bool found = _cartProductAppService.CheckCartProductExists(productid,username);

            try
            {
                if(found==false)
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

        [HttpDelete("{id}")]
        public IActionResult DeleteCartProduct(int id)
        {
            _cartProductAppService.DeletCartProduct(id);

            return NoContent();
        }

        private bool CartProductExists(int id)
        {
            // string username = User.Identity.Name;

            string username = "Asd";
            return _cartProductAppService.CheckCartProductExists(id, username);
        }
    }
}
