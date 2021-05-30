﻿using System.Collections.Generic;
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
    public class OfferController : ControllerBase
    {
        private readonly OfferAppservice _OfferAppService;

        public OfferController(OfferAppservice OfferOrderAppservice)
        {
            _OfferAppService = OfferOrderAppservice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferViewModel>>> GetOffers()
        {
            return _OfferAppService.GetAllOffers();
        }


        [HttpGet("{id}")]
        public ActionResult<OfferViewModel> GetOfferByID(int id)
        {
            var Offer = _OfferAppService.GetOffer(id);

            if (Offer == null)
            {
                return NotFound();
            }

            return Offer;
        }


        [HttpPut("{id}")]
        public IActionResult PutOffer(int id, OfferViewModel offerviewModel)
        {
            if (id != offerviewModel.ID)
            {
                return BadRequest();
            }

            try
            {
                _OfferAppService.UpdateOffer(offerviewModel);

                return Ok(offerviewModel);
            }


            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("CreateOffer")]
        public ActionResult<OfferViewModel> PostOffer(OfferViewModel offer)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //else
            //{
            //    try
            //    {
            _OfferAppService.AddOffer(offer);
            return Created("GetOffer",offer);

            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);

            //}
        
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOffer(int id)
    {
        _OfferAppService.DeleteOffer(id);
        return NoContent();
    }

    }
}
