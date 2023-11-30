



using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Models;
using ProductManagementApp.Services;

namespace ProductManagementApp.Controllers;

// ProductController class defines the API endpoints for managing products.
[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    // Private field to hold the ProductService instance for interacting with products.
    private readonly IProductService _productService;

    // Constructor that initializes the ProductController with an instance of IProductService.
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    // GET endpoint to retrieve all products.
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _productService.GetProducts();
        return Ok(products);
    }

    // GET endpoint to retrieve a product by its unique identifier.
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

    // POST endpoint to create a new product.
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

    // PUT endpoint to update an existing product.
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

    // DELETE endpoint to delete a product by its unique identifier.
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

    // GET endpoint to retrieve products by name.
    [HttpGet("list")]
    public IActionResult GetProductsByName([FromQuery] string name)
    {
        var productsByName = _productService.GetProductsByName(name);
        return Ok(productsByName);
    }

    // GET endpoint to retrieve sorted products by name.
    [HttpGet("list-sorted")]
    public IActionResult GetProductsByNameAndSort([FromQuery] string name, [FromQuery] string sort)
    {
        var productsByNameAndSort = _productService.GetProductsByNameAndSort(name, sort);
        return Ok(productsByNameAndSort);
    }
}