using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TBA.Model;
using TBA.Repositories;
using TBA.Repositories.Internal;

namespace TBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _employeeRepository.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeId }, employee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (id != employee.EmployeeId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.ManagerId = employee.ManagerId;
            existingEmployee.Role = employee.Role;

            await _employeeRepository.UpdateEmployeeAsync(existingEmployee);
            return NoContent();
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _employeeRepository.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
