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
    public class CategoryController : ControllerBase
    {
        CategoryAppService _categoryAppService;

        public CategoryController(CategoryAppService categoryAppService)
        {
            this._categoryAppService = categoryAppService;
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryAppService.GetAllCateogries());
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            return Ok(_categoryAppService.GetCategory(id));
        }
        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public IActionResult Create(CategoryViewModel categoryViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _categoryAppService.AddNewCategory(categoryViewModel);
                return Created("CreateCategory", categoryViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, CategoryViewModel categoryViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _categoryAppService.UpdateCategory(categoryViewModel);
                return Ok(categoryViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
       // [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryAppService.DeleteCategory(id);
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
            return Ok(_categoryAppService.CountEntity());
        }
        [HttpGet("{pageSize}/{pageNumber}")]
        public IActionResult GetCategoriesByPage(int pageSize, int pageNumber)
        {
            return Ok(_categoryAppService.GetPageRecords(pageSize, pageNumber));
        }

    }
}
