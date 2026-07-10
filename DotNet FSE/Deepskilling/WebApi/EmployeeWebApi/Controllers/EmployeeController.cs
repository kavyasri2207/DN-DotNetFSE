using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using EmployeeWebApi.Models;
using EmployeeWebApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthFilter] // Applied Auth filter to controller
    public class EmployeeController : ControllerBase
    {
        // Constructor: Create few records (handled by private method)
        public EmployeeController()
        {
        }

        // Get action method to return List of Employee class
        [HttpGet]
        [AllowAnonymous] // Bypasses the CustomAuthFilter for demonstration purposes
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Testing exception filter
        public ActionResult<IEnumerable<Employee>> Get()
        {
            // Task 3: Throw an exception in GET action method to trigger CustomExceptionFilter
            // Uncomment the line below to test the 500 Internal Server Error & File Logging:
            // throw new Exception("This is a simulated crash to test the CustomExceptionFilter!");

            return GetStandardEmployeeList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee newEmployee)
        {
            // Simulating saving the employee
            return Ok($"Successfully added {newEmployee.Name}!");
        }

        [HttpPut]
        public IActionResult Put([FromBody] Employee updatedEmployee)
        {
            return Ok($"Successfully updated {updatedEmployee.Name}!");
        }

        // Private method returning a List of Employee class
        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee 
                { 
                    Id = 1, 
                    Name = "Alice Johnson", 
                    Salary = 85000, 
                    Permanent = true, 
                    Department = new Department { Id = 10, Name = "Engineering" },
                    Skills = new List<Skill> 
                    { 
                        new Skill { Id = 100, Name = "C#" },
                        new Skill { Id = 101, Name = "SQL Server" }
                    },
                    DateOfBirth = new DateTime(1992, 5, 12)
                },
                new Employee 
                { 
                    Id = 2, 
                    Name = "Bob Smith", 
                    Salary = 72000, 
                    Permanent = false, 
                    Department = new Department { Id = 11, Name = "Sales" },
                    Skills = new List<Skill> 
                    { 
                        new Skill { Id = 102, Name = "Communication" }
                    },
                    DateOfBirth = new DateTime(1995, 8, 22)
                }
            };
        }
    }
}
