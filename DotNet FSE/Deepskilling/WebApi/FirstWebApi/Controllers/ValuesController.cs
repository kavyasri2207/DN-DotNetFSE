using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // 1. GET: api/Values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "value1", "value2", "value3" });
        }

        // 2. GET: api/Values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Successfully retrieved value ID: {id}");
        }

        // 3. POST: api/Values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok($"Successfully created new record: {value}");
        }

        // 4. PUT: api/Values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok($"Successfully updated ID {id} with data: {value}");
        }

        // 5. DELETE: api/Values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Successfully deleted ID {id}");
        }
    }
}
