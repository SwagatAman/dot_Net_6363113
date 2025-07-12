using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using MyReadWriteApi.Models;
using Microsoft.AspNetCore.Http;
using MyReadWriteApi.Filters;

namespace MyReadWriteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthFilter]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees;
        private static int _nextId = 1;

        static EmployeeController()
        {
            _employees = GetStandardEmployeeList();
            _nextId = _employees.Any() ? _employees.Max(e => e.Id) + 1 : 1;
        }

        private static List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = _nextId++,
                    Name = "Alice Smith",
                    Salary = 60000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Department = new Department { Id = 1, Name = "HR" }, // Correct initialization
                    Skills = new List<Skill> { new Skill { Id = 101, Name = "Recruitment" }, new Skill { Id = 102, Name = "Onboarding" } }
                },
                new Employee
                {
                    Id = _nextId++,
                    Name = "Bob Johnson",
                    Salary = 75000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1985, 10, 20),
                    Department = new Department { Id = 2, Name = "IT" }, // Correct initialization
                    Skills = new List<Skill> { new Skill { Id = 201, Name = "C#" }, new Skill { Id = 202, Name = "ASP.NET" } }
                },
                new Employee
                {
                    Id = _nextId++,
                    Name = "Charlie Brown",
                    Salary = 50000,
                    Permanent = false,
                    DateOfBirth = new DateTime(1992, 3, 10),
                    Department = new Department { Id = 1, Name = "HR" }, // Correct initialization
                    Skills = new List<Skill> { new Skill { Id = 103, Name = "Interviewing" } }
                }
            };
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return Ok(_employees.ToList());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> Get(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }
            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] Employee employee)
        {
            if (employee == null || string.IsNullOrWhiteSpace(employee.Name) || employee.Department == null)
            {
                return BadRequest("Invalid employee data. Name and Department are required.");
            }
            employee.Id = _nextId++;
            _employees.Add(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(int id, [FromBody] Employee employee)
        {
            if (employee == null || id != employee.Id)
            {
                return BadRequest("Employee ID mismatch or invalid data.");
            }
            var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }
            existingEmployee.Name = employee.Name;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Permanent = employee.Permanent;
            existingEmployee.DateOfBirth = employee.DateOfBirth;
            existingEmployee.Department = employee.Department;
            existingEmployee.Skills = employee.Skills;
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
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
}