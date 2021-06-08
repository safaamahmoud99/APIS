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

        // GET: api/Images
        [HttpGet]
        public ActionResult<IEnumerable<ImageViewModel>> Getimages(int productId)
        {

            return _imageAppService.GetAllImages().Where(i => i.productID == productId).ToList();
        }

        // GET: api/Images/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Images>> GetImages(int id)
        //{
        //    var images = await _context.images.FindAsync(id);

        //    if (images == null)
        //    {
        //        return NotFound();
        //    }

        //    return images;
        //}

        // PUT: api/Images/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public  ActionResult<ImageViewModel> PostImages(ImageViewModel imageViewModel)
        {

            _imageAppService.CreateImage(imageViewModel);
            return CreatedAtAction("GetImages", imageViewModel);
        }

        // DELETE: api/Images/5
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
    }
}
