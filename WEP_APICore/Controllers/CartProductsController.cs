//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using DAL;
//using DAL.Models;
//using BL.AppService;
//using BL.DTOs;

//namespace WEP_APICore.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CartProductsController : ControllerBase
//    {
//        private readonly CartProductAppService _cartProductAppService;

//        public CartProductsController(CartProductAppService cartProductAppService)
//        {
//            _cartProductAppService = cartProductAppService;
//        }

//        // GET: api/CartProducts
//        [HttpGet]
//        public ActionResult<IEnumerable<CartProductViewModel>> GetcartProducts()
//        {
//            return _cartProductAppService.GetAllCartProducts(); ;
//        }

//        // GET: api/CartProducts/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<CartProduct>> GetCartProduct(int id)
//        {
            

//            return cartProduct;
//        }

//        // PUT: api/CartProducts/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutCartProduct(int id, CartProduct cartProduct)
//        {
//            if (id != cartProduct.ID)
//            {
//                return BadRequest();
//            }

//            _context.Entry(cartProduct).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!CartProductExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/CartProducts
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<CartProduct>> PostCartProduct(CartProduct cartProduct)
//        {
//            _context.cartProducts.Add(cartProduct);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetCartProduct", new { id = cartProduct.ID }, cartProduct);
//        }

//        // DELETE: api/CartProducts/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCartProduct(int id)
//        {
//            var cartProduct = await _context.cartProducts.FindAsync(id);
//            if (cartProduct == null)
//            {
//                return NotFound();
//            }

//            _context.cartProducts.Remove(cartProduct);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool CartProductExists(int id)
//        {
//            return _context.cartProducts.Any(e => e.ID == id);
//        }
//    }
//}
