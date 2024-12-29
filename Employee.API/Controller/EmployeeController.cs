using Employee.API.Model;
using Employee.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var result = await _employeeRepository.GetAllEmployeeAsync();
            return Ok(result);
        }
         
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            var result = await _employeeRepository.GetAllEmployeeByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewEmployee([FromBody]EmployeeModel employeeModel)
        {
            var result = await _employeeRepository.AddEmployeeAsync(employeeModel);
            return CreatedAtAction(nameof(GetEmployeeById), new {id = result, controller = "Employee"}, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromBody]EmployeeModel employeeModel, [FromRoute]int id)
        {
            await _employeeRepository.UpdateEmployeeAsync(id,employeeModel);
            return Ok("Updated Existing Employee by Id");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchEmpolyee([FromRoute]int id, [FromBody]JsonPatchDocument jsonPatch)
        {
            if(jsonPatch == null)
            {
                return BadRequest();
            }

            await _employeeRepository.PatchEmployeeAsync(id, jsonPatch);
            return Ok("Patch Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEMployeeAsync(id);
            return Ok("Deleted");
        }


    }
}
