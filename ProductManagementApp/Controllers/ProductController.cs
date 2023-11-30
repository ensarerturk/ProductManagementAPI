



using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Models;
using ProductManagementApp.Services;

namespace ProductManagementApp.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _productService.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        try
        {
            var productById = _productService.GetProductById(id);
            return Ok(productById);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] Product newProduct)
    {
        try
        {
            _productService.CreateProduct(newProduct);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
    {
        try
        {
            _productService.UpdateProduct(id, updatedProduct);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        try
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("list")]
    public IActionResult GetProductsByName([FromQuery] string name)
    {
        var productsByName = _productService.GetProductsByName(name);
        return Ok(productsByName);
    }

    [HttpGet("list-sorted")]
    public IActionResult GetProductsByNameAndSort([FromQuery] string name, [FromQuery] string sort)
    {
        var productsByNameAndSort = _productService.GetProductsByNameAndSort(name, sort);
        return Ok(productsByNameAndSort);
    }
}