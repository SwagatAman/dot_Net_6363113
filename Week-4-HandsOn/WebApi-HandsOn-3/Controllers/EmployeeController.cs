using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("[controller]")]
 [CustomAuthFilter]
public class EmployeeController : ControllerBase
{
    private readonly List<Employee> _employees;

    public EmployeeController()
    {
        _employees = GetStandardEmployeeList();
    }

    private List<Employee> GetStandardEmployeeList()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John Doe",
                Salary = 60000,
                Permanent = true,
                Department = Department.IT,
                Skills = new List<Skill> { new Skill { Id = 101, Name = "C#" }, new Skill { Id = 102, Name = "ASP.NET Core" } },
                DateOfBirth = new DateTime(1990, 5, 15)
            },
            new Employee
            {
                Id = 2,
                Name = "Jane Smith",
                Salary = 75000,
                Permanent = false,
                Department = Department.HR,
                Skills = new List<Skill> { new Skill { Id = 201, Name = "Recruitment" }, new Skill { Id = 202, Name = "HR Policies" } },
                DateOfBirth = new DateTime(1985, 10, 20)
            },
            new Employee
            {
                Id = 3,
                Name = "Peter Jones",
                Salary = 50000,
                Permanent = true,
                Department = Department.Finance,
                Skills = new List<Skill> { new Skill { Id = 301, Name = "Accounting" }, new Skill { Id = 302, Name = "Taxation" } },
                DateOfBirth = new DateTime(1992, 3, 10)
            }
        };
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(List<Employee>), 200)]
    [ProducesResponseType(500)] // For custom exception filter demonstration
    public ActionResult<List<Employee>> GetStandard()
    {
        
        return Ok(_employees);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Employee), 200)]
    [ProducesResponseType(404)]
    public ActionResult<Employee> GetById(int id)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Employee), 201)]
    [ProducesResponseType(400)]
    public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
    {
        if (employee == null)
        {
            return BadRequest("Employee object cannot be null.");
        }

        // Simple validation, in a real app you'd have more robust validation
        if (string.IsNullOrEmpty(employee.Name))
        {
            return BadRequest("Employee name is required.");
        }

        // Assign a new ID (in a real app, this would be handled by a database)
        employee.Id = _employees.Max(e => e.Id) + 1;
        _employees.Add(employee);
        return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
    {
        if (updatedEmployee == null || id != updatedEmployee.Id)
        {
            return BadRequest("Invalid employee data or ID mismatch.");
        }

        var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
        if (existingEmployee == null)
        {
            return NotFound($"Employee with ID {id} not found.");
        }

        // Update properties
        existingEmployee.Name = updatedEmployee.Name;
        existingEmployee.Salary = updatedEmployee.Salary;
        existingEmployee.Permanent = updatedEmployee.Permanent;
        existingEmployee.Department = updatedEmployee.Department;
        existingEmployee.Skills = updatedEmployee.Skills;
        existingEmployee.DateOfBirth = updatedEmployee.DateOfBirth;

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteEmployee(int id)
    {
        var employeeToRemove = _employees.FirstOrDefault(e => e.Id == id);
        if (employeeToRemove == null)
        {
            return NotFound($"Employee with ID {id} not found.");
        }

        _employees.Remove(employeeToRemove);
        return NoContent();
    }
}