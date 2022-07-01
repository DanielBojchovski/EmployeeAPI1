using EmployeeAPI1.Models;
using EmployeeAPI1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmpRepository _empRepository;
        public EmployeesController(IEmpRepository empRepository)
        {
            _empRepository = empRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _empRepository.Get();
        }


        [HttpGet("{EmpId}")]
        public async Task<ActionResult<Employee>> GetEmployees(int EmpId)
        {
            var employee = await _empRepository.Get(EmpId);
            if (employee == null)
                return NotFound("Employee id does not exist./ Вработен со овој идентификационен број не постои.");
            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployees(Employee employee)
        {
            var newEmployee = await _empRepository.Create(employee);
            return CreatedAtAction(nameof(GetEmployees), new { EmpId = newEmployee.Id }, newEmployee);
        }

        [HttpPut]
        public async Task<ActionResult> PutEmployees(int EmpId, Employee employee)
        {
            if (EmpId != employee.Id)
            {
                return BadRequest("There is no employee with that id or id is already taken./ Не постои вработен со тој број или бројот е веќе зафатен.");
            }

            await _empRepository.Update(employee);
            return NoContent();
        }

        [HttpDelete("{EmpId}")]
        public async Task<ActionResult> Delete(int EmpId)
        {

            var employeeToDelete = await _empRepository.Get(EmpId);
            if (employeeToDelete == null)
            {
                return NotFound("Employee id does not exist. No employee was deleted./ Вработен со овој идентификационен број не постои. Ниту еден вработен не беше избришан");
            }

            await _empRepository.Delete(employeeToDelete.Id);

            return NoContent();
        }
    }
}
