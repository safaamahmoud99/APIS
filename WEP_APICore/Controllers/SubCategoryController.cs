using BL.AppService;
using BL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEP_APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        SubCategoryAppService _subcategoryAppService;

        public SubCategoryController(SubCategoryAppService subcategoryAppService)
        {
            this._subcategoryAppService = subcategoryAppService;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_subcategoryAppService.GetAllSubCateogries());
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            return Ok(_subcategoryAppService.GetSubCategory(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(SubCategoryViewModel categoryViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _subcategoryAppService.AddNewCategory(categoryViewModel);
                return Created("CreateCategory", categoryViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Edit(int id, SubCategoryViewModel subcategoryViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _subcategoryAppService.UpdateSubCategory(subcategoryViewModel);
                return Ok(subcategoryViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _subcategoryAppService.DeleteSubCategory(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
