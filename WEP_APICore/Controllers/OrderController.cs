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
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WEP_APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderAppService  _OrderAppService;
        private readonly OrderDetailsAppservice _OrderDetailsAppService;
        private readonly ProductAppService _productAppService;
        private readonly CartProductAppService _CartProductsAppService;
        private readonly AccountAppService _AccountappService;
        private IHttpContextAccessor _httpContextAccessor;
        private CartAppService _CartAppService;
        public OrderController(OrderAppService orderAppservice,OrderDetailsAppservice orderDetailsAppService, ProductAppService productAppService,
            CartProductAppService cartProductsAppService, IHttpContextAccessor httpContextAccessor, AccountAppService accountappService, CartAppService cartAppService)           
        {
            _OrderAppService = orderAppservice;
            _OrderDetailsAppService =orderDetailsAppService;
            _productAppService = productAppService;
            _CartProductsAppService = cartProductsAppService;
            _httpContextAccessor = httpContextAccessor;
            _AccountappService = accountappService;
            _CartAppService = cartAppService;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetOrders()
        {
            return _OrderAppService.GetAllOrder();
        }        
        [HttpGet("{id}")]
        public ActionResult<OrderViewModel> GetOrderByID(int id)
        {
            var Order = _OrderAppService.GetOrder(id);
            if (Order == null)
            {
                return NotFound();
            }
            return Order;
        }


        [Authorize]
        [HttpGet("Checkout")]
        public async Task<IActionResult> CheckoutAsync()
        {
            var currentUser = await _AccountappService.FindByName(User.Identity.Name);
            ////get cart id of current logged user
            //var userID = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var userid = "d4a62c76-1ca4-41e7-ba6a-65af5a84d1fb";
            var userid = currentUser.Id;
            int proid;

            var cart = _CartAppService.GetCartByUser(userid);
            //double netPrice=0;

            OrderViewModel orderViewModel = new OrderViewModel
            {
                OrderDate = DateTime.Now.ToString(),
                totalPrice = cart.TotalPrice,
                UserID = cart.UserID,
                OrderDetails = new List<OrderDetails>()
            };
           
            foreach (var item in cart.cartProducts)
            {
                var orderdetail = new OrderDetails
                {
                    ProductID = item.productId,
                    Quantity = item.quintity

                };

                var product = _productAppService.GetProduct(item.productId);
                 
                product.Quantity -= item.quintity;
                //if (product.Quantity == 0)
                //{
                //    //_productAppService.DeleteProduct(product.ID);
                //    //proid = product.ID;
                //}
                //else
                //{
                    _productAppService.UpdateProduct(product);
                //}
                orderViewModel.OrderDetails.Add(orderdetail);
                

            }
             
            _OrderAppService.SaveNewOrder(orderViewModel);
            await _CartProductsAppService.DeletAllCartProduct(cart.UserID);
         

            return Ok();
        }

        [HttpGet("GetOrderDetails")]
        public ActionResult<IEnumerable<OrderDetails>> GetOrderDetails(int id)
        {

            return _OrderDetailsAppService.GetAllOrderDetailsbyOrderID().Where(i => i.OrderID == id).ToList();
        }

        [HttpGet("GetUserOrders")]
        public ActionResult<IEnumerable<OrderViewModel>> GetAllOrdersbyUser(string  id)
        {

            return _OrderAppService.GetAllOrder().Where(i => i.UserID == id).ToList();
        }






        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            _OrderAppService.DeleteOrder(id);
            return NoContent();
        }
        private bool OrderExists(OrderViewModel orderViewModel)
        {
            return _OrderAppService.CheckOrderExists(orderViewModel);
        }
        [HttpGet("count")]
        public IActionResult OrdersCount()
        {
            return Ok(_OrderAppService.CountEntity());
        }
        [HttpGet("{pageSize}/{pageNumber}")]
        public IActionResult GetOrderByPage(int pageSize, int pageNumber)
        {
            return Ok(_OrderAppService.GetPageRecords(pageSize, pageNumber));
        }

    }
}

