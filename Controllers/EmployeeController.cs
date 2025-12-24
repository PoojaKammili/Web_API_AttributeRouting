using Microsoft.AspNetCore.Mvc;
using Web_API_AttributeRouting.Services;
using Web_API_AttributeRouting.Models;

namespace Web_API_AttributeRouting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service;
        public EmployeeController(EmployeeService service) { _service = service; }
        //create
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Employee employee)
        {
            var emp = _service.CreateEmployee(employee);
            return CreatedAtAction(nameof(GetById), new { Id = emp.Id }, emp);
        }

        //addmultiple 
        [HttpPost("CreateMultiple")]
        public IActionResult CreateMultiple([FromBody] List<Employee> employees)
        {
            foreach (var emp in employees)
            {
                _service.CreateEmployee(emp);
            }
            return Ok("Employees added successfully");
        }
        //getall
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var emp = _service.GetEmployees();
            if (emp == null || emp.Count == 0)
            {
                return BadRequest("No Employee Found");
            }
            else
            {
                return Ok(emp);
            }
        }
        //getbyid
        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var emp = _service.GetEmployeeById(id);
            if (emp == null)
            {
                return BadRequest($"No Employee found with id : {id}");
            }
            else
            {
                return Ok(emp);
            }
        }
        //getbydept
        [HttpGet("GetByDept")]
        public IActionResult GetByDept([FromQuery] string department)
        {
            var emp = _service.GetEmployeeByDept(department);
            if(emp == null && emp.Count == 0)
            {
                return BadRequest($"No employee found with department : {department}");
            }
            return Ok(emp);
        }
        //update
        [HttpPut("Update")]

        public IActionResult Update([FromQuery]int id,[FromBody]Employee employee)
        {
            var emp = _service.UpdateEmployee(employee.Id);
            if (emp == null)
            {
                return NotFound("Employee not found");
            }
            emp.Name = employee.Name;
            emp.Department = employee.Department;
            emp.Salary = employee.Salary;
            return Ok(emp);
        }
        //delete
        [HttpDelete("Delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            var emp = _service.GetEmployeeById(id);
            if (emp.Id == null)
            {
                return BadRequest("No student found");
                
            }
            _service.DeleteEmployee(id);
            return NoContent();
        }
    }
}
