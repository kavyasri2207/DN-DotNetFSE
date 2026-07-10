using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EmployeeCrudWebApi.Models;

namespace EmployeeCrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // Static in-memory list acts as our database to persist updates across requests!
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice Johnson", Salary = 50000 },
            new Employee { Id = 2, Name = "Bob Smith", Salary = 60000 },
            new Employee { Id = 3, Name = "Charlie Brown", Salary = 70000 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return Ok(_employees);
        }

        // Action method mapped with Http PUT action verb to update an employee data
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmployee)
        {
            // 1. Check if the id value is lesser than or equal to 0
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            // 2. Check if the value is available in the hardcoded list
            var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            // 3. Use the JSON data from the input body and update the hardcoded list
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Salary = updatedEmployee.Salary;

            // 4. Return the updated Employee data thru ActionResult
            return Ok(existingEmployee);
        }
    }
}
