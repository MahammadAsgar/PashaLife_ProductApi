using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductApi.Data.ViewModel;
using ProductApi.Services;
using ProductApi.Services.Abstract;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IProductCategoryRepository _service;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(IProductCategoryRepository service, ILogger<CategoryController> logger)
        {
             _logger = logger;
            _service = service;
        }

        [HttpPost("add-category-category")]
        public IActionResult AddProductCategory([FromBody] ProductCategoryVM category)
        {
            _logger.LogInformation("This is AddProductCategory()");
            _service.AddProductCategory(category);
            return Ok(category);
        }

        [HttpPut("update-category_by-id")]
        public IActionResult UpdateProductCategory(int id, [FromBody] ProductCategoryVM categoryVM)
        {
            _logger.LogInformation("This is UpdateProductCategory()");
            var category = _service.UpdateProductCategory(id, categoryVM);
            return Ok(category);
        }
        [HttpDelete("delete-category-by-id")]
        public IActionResult DeleteProductCategory(int id)
        {
            _logger.LogInformation("This is DeleteProductCategory()");
            _service.DeleteProductCategory(id);
            return Ok();
        }
        [HttpGet("get-category-by-id")]
        public IActionResult GetProductCategoryById(int id)
        {
            _logger.LogInformation("This is GetProductCategory()");
            var category = _service.GetProductCategory(id);
            return Ok(category);
        }

        [HttpGet("get-categories")]
        public IActionResult GetProductCategories()
        {
            _logger.LogInformation("This is GetAllProductCategories()");
            var categories = _service.GetAllProductCategories();
            return Ok(categories);
        }
    }
}
