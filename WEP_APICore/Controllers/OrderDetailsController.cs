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
    public class OrderDetailsController : ControllerBase
    {
        private readonly OrderDetailsAppservice _OrderDetailsAppService;

        public OrderDetailsController(OrderDetailsAppservice OrderDetailAppservice)
        {
            _OrderDetailsAppService = OrderDetailAppservice;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetailsViewModel>>> GetOrderDetails()
        {
            return _OrderDetailsAppService.GetAllOrderDetails();
        }

        // GET: api/OrderDetails/2
        [HttpGet("{id}")]
        public ActionResult<OrderDetailsViewModel> GetOrderDetailsByID(int id)
        {
            var OrderDetail = _OrderDetailsAppService.GetOrderDetailsbyID(id);

            if (OrderDetail == null)
            {
                return NotFound();
            }

            return OrderDetail;
        }


        

       // POST: api/Reviews
       // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       [HttpPost]
        public ActionResult<OrderDetailsViewModel> PostOrderDetails(OrderDetailsViewModel orderDetail)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //else
            //{
            //    try
            //    {
                    _OrderDetailsAppService.SaveNewOrderDetail(orderDetail);
                    return Created("GetOrderDetails", orderDetail);

                //}
                //catch (Exception ex)
                //{
                //    return BadRequest(ex.Message);

                //}
             
        }

         
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetails(int id)
        {
            _OrderDetailsAppService.DeleteOrderDetails(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult PutOrderDetails(int id, OrderDetailsViewModel OrderDetail)
        {
            

            try
            {
                _OrderDetailsAppService.UpdateOrderDetails(OrderDetail);

                return Ok(OrderDetail);
            }


            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
