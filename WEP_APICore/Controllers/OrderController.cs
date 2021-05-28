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

namespace WEP_APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderAppService  _OrderAppService;

        public OrderController(OrderAppService OrderAppservice)
        {
            _OrderAppService = OrderAppservice;
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
        public IActionResult PutOrder(OrderViewModel newOder)
        {
            _OrderAppService.UpdateOrder(newOder);
            return Ok();
        }

         
        [HttpPost]
        public ActionResult<OrderViewModel> PostOrder(OrderViewModel order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    _OrderAppService.SaveNewOrder(order);
                    return CreatedAtAction("GetOrder", new { id = order.Id }, order);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);

                }
            }
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

