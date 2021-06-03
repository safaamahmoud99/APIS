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
    public class MainCategoryController : ControllerBase
    {
        private readonly MainCategoryAppService _mainCategoryAppService;
        public MainCategoryController(MainCategoryAppService maincategoryAppService)
        {
            _mainCategoryAppService = maincategoryAppService;
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_mainCategoryAppService.GetAllMainCateogries());
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            return Ok(_mainCategoryAppService.GetMainCategory(id));
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult Create(MainCategoryViewModel maincategoryViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _mainCategoryAppService.AddMainCategory(maincategoryViewModel);

                return Created("CreateCategory", maincategoryViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Edit(int id, MainCategoryViewModel maincategoryViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _mainCategoryAppService.UpdateMainCategory(maincategoryViewModel);
                return Ok(maincategoryViewModel);
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
                _mainCategoryAppService.DeletMaineCategory(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
