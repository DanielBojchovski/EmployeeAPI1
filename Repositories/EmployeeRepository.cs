using EmployeeAPI1.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI1.Repositories
{
    public class EmployeeRepository : IEmpRepository
    {
        private readonly EmployeeContext _context;
        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<Employee> Create(Employee employee)
        {
            _context.employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task Delete(int EmpId)
        {
            var employeeToDelete = await _context.employees.FindAsync(EmpId);
            _context.employees.Remove(employeeToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _context.employees.ToListAsync();
        }

        public async Task<Employee> Get(int EmpId)
        {
            return await _context.employees.FindAsync(EmpId);
        }

        public async Task Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
