using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SwaggerWebApi.Controllers
{
    // Task 3: Modified the Controller name in the Route attribute to 'Emp'
    [Route("api/Emp")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // Simple Employee list for testing
        private static readonly List<string> Employees = new List<string> 
        { 
            "Alice Johnson", 
            "Bob Smith", 
            "Charlie Brown" 
        };

        // 2. GET action method to be tested via POSTMAN
        [HttpGet(Name = "GetEmployees")]
        public IActionResult Get()
        {
            return Ok(Employees);
        }
    }
}
