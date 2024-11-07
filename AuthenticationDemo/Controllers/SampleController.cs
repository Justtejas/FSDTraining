using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController:ControllerBase
    {
        [Authorize(Roles = "Admin")]
        //[AllowAnonymous]
        [HttpGet]
        public string GetSampleData()
        {
            return "Sample Data from Sample Controller";
        }
    }
}
