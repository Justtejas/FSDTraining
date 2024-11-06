using DBFAAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DBFAAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IBrandServices _brandServices;
        public BrandController(IBrandServices brandServices)
        {
            _brandServices = brandServices;
        }
        [HttpGet]
        public IActionResult GetAllBrands()
        {
            var brands = _brandServices.GetAllBrands();
            if (brands == null || brands.Count == 0)
            {
                return NotFound("No Brands Found");
            }
            return Ok(brands);
        }
        [HttpGet("brand/{id}")]
        public IActionResult GetBrandByID(int id)
        {
            var brand = _brandServices.GetBrandByID(id);
            if(brand == null)
            {
                return NotFound("No Brand Found");
            }
            return Ok(brand);
        }
    }
}
