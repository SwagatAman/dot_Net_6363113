using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MyReadWriteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private static List<string> _values = new List<string> { "value1", "value2", "value3" };

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_values.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= _values.Count)
            {
                return NotFound($"Value with ID {id} not found.");
            }
            return Ok(_values[id]);
        }

        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return BadRequest("Value cannot be empty.");
            }
            _values.Add(value);
            return CreatedAtAction(nameof(Get), new { id = _values.Count - 1 }, value);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= _values.Count)
            {
                return NotFound($"Value with ID {id} not found.");
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                return BadRequest("Value cannot be empty.");
            }
            _values[id] = value;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= _values.Count)
            {
                return NotFound($"Value with ID {id} not found.");
            }
            _values.RemoveAt(id);
            return NoContent();
        }
    }
}
