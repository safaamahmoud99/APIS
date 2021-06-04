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
        // GET: api/Advertisements
        [HttpGet]
        public ActionResult<IEnumerable<AdvertisementViewModel>>GetAdvertisements()
        {
            return _advertisementApp.GetAllAdvertisements();
        }
        [AllowAnonymous]
        // GET: api/Advertisements/5
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
        // POST: api/Advertisements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
        [Authorize(Roles = "Admin")]
        // DELETE: api/Advertisements/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAdvertisement(int id)
        {
            _advertisementApp.DeletAdvertisement(id);

            return NoContent();
        }

        
    }
}
