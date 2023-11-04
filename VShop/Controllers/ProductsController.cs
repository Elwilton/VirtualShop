using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VShop.DTOs;
using VShop.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VShop.Controllers;

[Route("api/[controller]")]
public class ProductsController : Controller
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: api/values
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        var productDto = await _productService.GetProducts();
        if (productDto is null)

            return NotFound("Categories Not Found");

        return Ok(productDto);
    }


    // GET api/values/5
    [HttpGet("{id}")]
    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get(int id)
    {
        var productDto = await _productService.GetProductById(id);
        if (productDto is null)

            return NotFound("Categories Not Found");

        return Ok(productDto);
    }

    // POST api/values
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
    {
        if (productDto == null)
            return BadRequest("Invalid Data");
        await _productService.AddProduct(productDto);

        return new CreatedAtRouteResult("GetCategory", new { id = productDto.Id }, productDto);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDto)
    {

        if (id != productDto.Id)
            return BadRequest();

        if (productDto == null)
            return BadRequest();

        await _productService.UpdateProduct(productDto);
        return Ok(productDto);
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductDTO>> Delete(int id)
    {
        var productDto = await _productService.GetProductById(id);
        if (productDto == null)
        {
            return NotFound("Cattegory not found");
        }
        await _productService.RemovProduct(id);

        return Ok(productDto);
    }
}

