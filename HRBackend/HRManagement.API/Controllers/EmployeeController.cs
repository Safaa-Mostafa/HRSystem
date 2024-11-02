using HRManagement.API.ResponseModels;
using HRManagement.BL.DTO;
using HRManagement.BL.Managers.Employee;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                return BadRequest("Employee data is null.");
            }
            var result = await _employeeManager.Add(employeeDTO);
            var response = APIResponse<GetEmployeeDTO>.SuccessResponse(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeManager.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _employeeManager.GetById(id);
            var response = APIResponse<GetEmployeeDTO>.SuccessResponse(result);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditEmployeeDTO editEmployeeDTO)
        {
            var result = await _employeeManager.Update(id, editEmployeeDTO);
            if (result == null) return NotFound();
            var response = APIResponse<GetEmployeeDTO>.SuccessResponse(result);
            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchEmployees([FromQuery] string? searchTerm, [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var employees = await _employeeManager.SearchEmployeesAsync(searchTerm, pageNumber, pageSize);
            var response = APIResponse<IEnumerable<GetEmployeeDTO>>.SuccessResponse(employees);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> Employees([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var employees = await _employeeManager.GetAll(pageNumber, pageSize);
            var response = APIResponse<IEnumerable<GetEmployeeDTO>>.SuccessResponse(employees);
            return Ok(response);
        }
        [HttpPut("activate/{id}")]
        public async Task<IActionResult> ActiveEmployee(int id)
        {
            await _employeeManager.ActiveEmployee(id);

            return NoContent();
        }
        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeActiveEmployee(int id)
        {
            await _employeeManager.DeActiveEmployee(id);

            return NoContent();
        }
    }
}
