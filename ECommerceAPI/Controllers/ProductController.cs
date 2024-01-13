using ECommerceAPI.Models.Repositories;
using ECommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Filters;
using ECommerceAPI.Filters.ActionFilters;
using ECommerceAPI.Filters.ExceptionFilters;


namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(ProductRepository.GetProducts());
        }

        [HttpGet("{id}")]
        [Product_ValidateProductIdFilter]
        public IActionResult GetProductById(int id)
        {
            return Ok(ProductRepository.GetProductById(id));
        }

        [HttpPost]
        [Product_ValidateCreateProductFilter]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            // Add validation or business logic if needed
            ProductRepository.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        [Product_ValidateProductIdFilter]
        [Product_ValidateUpdateProductFilter]
        [Product_HandleUpdateExceptionsFilter]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            // Add validation or business logic if needed
            ProductRepository.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Product_ValidateProductIdFilter]
        public IActionResult DeleteProduct(int id)
        {
            var product = ProductRepository.GetProductById(id);
            ProductRepository.DeleteProduct(id);
            return Ok(product);
        }
    }
}
