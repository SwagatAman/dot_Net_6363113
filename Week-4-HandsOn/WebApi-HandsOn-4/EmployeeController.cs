using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Filters;
using MyFirstWebApi.Models;

namespace MyFirstWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(CustomAuthFilter))] // ✅ Custom authorization filter applied
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Alice",
                Salary = 50000,
                Permanent = true,
                Department = new Department { Id = 1, Name = "HR" },
                Skills = new List<Skill>
                {
                    new Skill { Id = 1, Name = "Communication" },
                    new Skill { Id = 2, Name = "Teamwork" }
                },
                DateOfBirth = new DateTime(1990, 1, 1)
            }
        };

        // ✅ READ (GET all)
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> Get()
        {
            // Uncomment for exception test
            // throw new Exception("This is a test exception");
            return Ok(_employees);
        }

        // ✅ CREATE (POST)
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee emp)
        {
            emp.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(emp);
            return Ok(emp);
        }

        // ✅ UPDATE (PUT)
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmp)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return BadRequest("Invalid employee id");

            employee.Name = updatedEmp.Name;
            employee.Salary = updatedEmp.Salary;
            employee.Permanent = updatedEmp.Permanent;
            employee.Department = updatedEmp.Department;
            employee.Skills = updatedEmp.Skills;
            employee.DateOfBirth = updatedEmp.DateOfBirth;

            return Ok(employee);
        }

        // ✅ DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound("Employee not found");

            _employees.Remove(emp);
            return Ok($"Employee with ID {id} deleted.");
        }
    }
}