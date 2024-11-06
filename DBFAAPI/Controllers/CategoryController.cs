using DBFAAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DBFAAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController:Controller
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryServices.GetAllCategories();
            if (categories == null)
            {
                return NotFound("There are no categories");
            }
            return Ok(categories);
        }

        [HttpGet("category/{id}")]
        public IActionResult GetCategoryByID(int id)
        {
            var category = _categoryServices.GetCategoryByID(id);
            if (category == null)
            {
                return NotFound($"Not Found any category with categoryID: {id}");
            }
            return Ok(category);

        }
    }
}
