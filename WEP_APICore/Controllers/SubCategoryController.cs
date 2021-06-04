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
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
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
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
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
        [HttpGet("count")]
        public IActionResult CategoriesCount()
        {
            return Ok(_subcategoryAppService.CountEntity());
        }
        [HttpGet("{pageSize}/{pageNumber}")]
        public IActionResult GetCategoriesByPage(int pageSize, int pageNumber)
        {
            return Ok(_subcategoryAppService.GetPageRecords(pageSize, pageNumber));
        }
    }
}
