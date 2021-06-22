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
    public class ImagesController : ControllerBase
    {
        private readonly ImageAppService _imageAppService;     
        public ImagesController(ImageAppService imageAppService)
        {
            _imageAppService = imageAppService;          
        }
        [HttpGet]
        public ActionResult<IEnumerable<ImageViewModel>> Getimages()
        {
            return _imageAppService.GetAllImages();
        }
        [HttpGet("{productId}")]
        public ActionResult<IEnumerable<ImageViewModel>> GetimagesAll(int productId)
        {

            return _imageAppService.GetAllImages().Where(i => i.productID == productId).ToList();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult PutImages(int id, ImageViewModel imageViewModel)
        {        
            try
            {
                _imageAppService.UpdateImage(imageViewModel);
                return Ok(imageViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public  ActionResult<ImageViewModel> PostImages(ImageViewModel imageViewModel)
        {
            _imageAppService.CreateImage(imageViewModel);
            return CreatedAtAction("GetImages", imageViewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteImages(int id)
        {
            _imageAppService.DeleteImage(id);
            return NoContent();
        }
        private bool ImagesExists(int id)
        {
            return _imageAppService.CheckImageExists(id);
        }
        [HttpGet("count")]
        public IActionResult ImagesCount()
        {
            return Ok(_imageAppService.CountEntity());
        }
        [HttpGet("{pageSize}/{pageNumber}")]
        public IActionResult GetImagesByPage(int pageSize, int pageNumber)
        {
            return Ok(_imageAppService.GetPageRecords(pageSize, pageNumber));
        }
    }
}
