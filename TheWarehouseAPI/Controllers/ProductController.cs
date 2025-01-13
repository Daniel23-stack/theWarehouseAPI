
using Microsoft.AspNetCore.Mvc;
using TheWarehouseAPI.DTOs;
using TheWarehouseAPI.Models;
using TheWarehouseAPI.Services;

namespace TheWarehouseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO productDto)
        {
            if (string.IsNullOrEmpty(productDto.Code) || string.IsNullOrEmpty(productDto.Description))
            {
                return BadRequest("Product code and description are required.");
            }

            await _productService.CreateProductAsync(productDto);
            return CreatedAtAction(nameof(GetAll), new { code = productDto.Code }, productDto);
        }
    }
}