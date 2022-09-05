using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductApi.Data.ViewModel;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _service;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductRepository service, ILogger<ProductController> logger)
        {
            _logger = logger;
            _service = service;
        }
        [HttpPost("add-product")]
        public IActionResult AddProduct([FromBody] ProductVM product)
        {
            _logger.LogInformation("This is AddProduct()");
            _service.AddProduct(product);
            return Ok(product);
        }

        [HttpPut("update-product-by-id")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductVM productVM)
        {
           _logger.LogInformation("This is UpdateProduct()");
            var product = _service.UpdateProduct(id, productVM);
            return Ok(product);
        }

        [HttpDelete("delete-product-by-id")]
        public IActionResult DeleteProduct(int id)
        {
            _logger.LogInformation("This is DeleteProduct()");
            _service.DeleteProduct(id);
            return Ok();
        }

        [HttpGet("get-product-by-id")]
        public IActionResult GetProductById(int id)
        {
            _logger.LogInformation("This is GetProduct()");
            var product = _service.GetProduct(id);
            return Ok(product);
        }

        [HttpGet("get-all-products")]
        public IActionResult GetAllProducts()
        {
            _logger.LogInformation("his is GetAllProducts()");
            var products = _service.GetAllProducts();
            return Ok(products);
        }
    }
}
