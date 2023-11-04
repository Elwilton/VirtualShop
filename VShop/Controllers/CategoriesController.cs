using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VShop.DTOs;
using VShop.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VShop.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categoriesDto = await _categoryService.GetCategories();
            if(categoriesDto is null)
            
                return NotFound("Categories Not Found");

            return Ok(categoriesDto);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
        {
            var categoriesDto = await _categoryService.GetCategoriesProducts();
            if (categoriesDto is null)

                return NotFound("Categories Not Found");

            return Ok(categoriesDto);
        }
        // GET api/values/5
        [HttpGet("{id:int}", Name ="GetCategory")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get(int id)
        {
            var categoriesDto = await _categoryService.GetCategoriesById(id);
            if (categoriesDto is null)

                return NotFound("Categories Not Found");

            return Ok(categoriesDto);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
                return BadRequest("Invalid Data");
            await _categoryService.AddCategory(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.CatogoryId }, categoryDto);
        }

        // PUT api/values/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {

            if (id != categoryDto.CatogoryId)
                return BadRequest();

            if (categoryDto == null)
                return BadRequest();

            await _categoryService.UpdateCategory(categoryDto);
            return Ok(categoryDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categoryDto = await _categoryService.GetCategoriesById(id);
            if(categoryDto == null)
            {
                return NotFound("Cattegory not found");
            }
            await _categoryService.RemoveCategory(id);

            return Ok(categoryDto);
        }
    }
}

