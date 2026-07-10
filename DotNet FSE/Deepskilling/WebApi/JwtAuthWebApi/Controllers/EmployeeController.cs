using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Task 4: Include the role 'Admin' along with 'POC' in the Authorize attribute
    [Authorize(Roles = "Admin,POC")] 
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // Protected endpoint returning dummy data
            return Ok(new string[] { "Alice Johnson", "Bob Smith", "Charlie Brown" });
        }
    }
}
