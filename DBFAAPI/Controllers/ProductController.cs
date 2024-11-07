using DBFAAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DBFAAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productServices.GetAllProducts();
            if (products == null)
            {
                return NotFound("No products found");
            }
            return Ok(products);
        }

        [HttpGet("product/id/{id}")]
        public IActionResult GetProductByID(int id)
        {
            var product = _productServices.GetProductByID(id);
            if (product == null)
            {
                return NotFound($"No product found with id: {id}");
            }
            return Ok(product);
        }

        [HttpGet("product/name/{productName:length(3,12)}")]
        public IActionResult GetProductByName(string productName)
        {
            var products = _productServices.GetProductByName(productName);
            if (products == null)
            {
                return NotFound($"No products found with name: {productName}");
            }
            return Ok(products);
        }

        [HttpGet("category/{id}")]
        public IActionResult GetProductFromCategory(int id)
        {
            var products = _productServices.GetProductFromCategory(id);
            if(products == null)
            {
                return NotFound($"No products found from category id: {id}");
            }
            return Ok(products);
        }
    }
}
