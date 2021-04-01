using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //[HttpGet("getall")] // -> https://localhost:44332/api/products/getall

        [HttpGet] // -> https://localhost:44332/api/products
        public IActionResult Get()
        {
            var result = _productService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        //[HttpGet("getbyid")] // -> https://localhost:44332/api/products/getbyid?id=78

        [HttpGet("{id}")] //-> https://localhost:44332/api/products/78
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success) return Ok(result);
            return NotFound(result);
        }

        [HttpGet("getbycategory")] //-> https://localhost:44332/api/products/getbycategory?categoryId=2
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetProductsByCategoryId(categoryId);
            if (result.Success) return Ok(result);
            return NotFound(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.AddProduct(product);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
