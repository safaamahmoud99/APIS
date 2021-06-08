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


        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, OrderViewModel orderViewModel)
        {
            try
            {
                _OrderAppService.UpdateOrder(orderViewModel);

                return Ok(orderViewModel);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //// GET: api/Orders for one User
        //[HttpGet]
        //public ActionResult<IEnumerable<OrderViewModel>> GetOrders(String UserID)
        //{

        //    return _OrderAppService.GetAllOrder().Where(i => i.UserID == UserID).ToList();
        //}

        [HttpPost]
        public ActionResult<OrderViewModel> PostOrder(OrderViewModel order)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //else
            //{
            //    try
            //    {
                    _OrderAppService.SaveNewOrder(order);
                    return Created("GetOrder" , order);

            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);

            //}

        }

        //[Authorize]
        [HttpGet("Checkout")]
        public IActionResult Checkout()
        {
            //var currentUser = _AccountappService.FindByName(User.Identity.Name);
            ////get cart id of current logged user
            //var userID = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userID = "2d30f7bf-86ce-43e6-a3cc-ae9cb4fb45c2";
            var cart = _CartAppService.GetCartByUser(userID);
            double netPrice=0;

            OrderViewModel orderViewModel = new OrderViewModel
            {
                OrderDate = DateTime.Now.ToString(),
                totalPrice = /*cart.TotalPrice*/100,
                UserID = /*cart.ID*/"2d30f7bf-86ce-43e6-a3cc-ae9cb4fb45c2",
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
                //netPrice += item.quintity * product.Price;
                product.Quantity -= item.quintity;
                _productAppService.UpdateProduct(product);
                orderViewModel.OrderDetails.Add(orderdetail);
            }
            //_CartAppService.DeleteCartByUser(userID);
            _OrderAppService.SaveNewOrder(orderViewModel);
            return Ok();
        }

        [HttpGet("GetOrderDetails")]
        public ActionResult<IEnumerable<OrderDetails>> GetOrderDetails(int OrderID)
        {

            return _OrderDetailsAppService.GetAllOrderDetailsbyOrderID().Where(i => i.OrderID == OrderID).ToList();
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

    }
}

