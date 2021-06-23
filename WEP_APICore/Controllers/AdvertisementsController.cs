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
using Microsoft.AspNetCore.Authorization;

namespace WEP_APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        private readonly AdvertisementAppService _advertisementApp;

        public AdvertisementsController(AdvertisementAppService advertisementApp)
        {
            _advertisementApp = advertisementApp;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<AdvertisementViewModel>>GetAdvertisements()
        {
            return _advertisementApp.GetAllAdvertisements();
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<AdvertisementViewModel> GetAdvertisement(int id)
        {
            var advertisement = _advertisementApp.GetAdvertisement(id);

            if (advertisement == null)
            {
                return NotFound();
            }

            return advertisement;
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult PutAdvertisement(int id, AdvertisementViewModel advertisementViewModel)
        {          
            try
            {
                _advertisementApp.UpdateAdvertisement(advertisementViewModel);
                return Ok(advertisementViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<AdvertisementViewModel> PostAdvertisement(AdvertisementViewModel advertisement)
        {         
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    _advertisementApp.CreateAdvertisement(advertisement);
                    return Ok();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);

                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAdvertisement(int id)
        {
            _advertisementApp.DeletAdvertisement(id);

            return NoContent();
        }
        [HttpGet("count")]
        public IActionResult AdvertisementCount()
        {
            return Ok(_advertisementApp.CountEntity());
        }
        [HttpGet("{pageSize}/{pageNumber}")]
        public IActionResult GetAdvertisementByPage(int pageSize, int pageNumber)
        {
            return Ok(_advertisementApp.GetPageRecords(pageSize, pageNumber));
        }
    }
}
