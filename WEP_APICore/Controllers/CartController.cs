using BL.AppService;
using BL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WEP_APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {


        private readonly CartAppService _cartAppService;


        public CartController(CartAppService cartAppService)
        {
            _cartAppService = cartAppService;
        }

        [HttpGet]
        public ActionResult<CartViewModel> GetCart(string cartID)
        {

            var cart = _cartAppService.GetCart(cartID);
            return cart;
        }
    }
}
