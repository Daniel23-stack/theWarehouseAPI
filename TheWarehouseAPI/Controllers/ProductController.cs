
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
        public async Task<IActionResult> GetAll() => Ok(await _productService.GetAllProductsAsync());

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            var product = new Product { Code = productDto.Code, Description = productDto.Description };
            var createdProduct = await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetAll), new { id = createdProduct.Id }, createdProduct);
        }
    }
}
