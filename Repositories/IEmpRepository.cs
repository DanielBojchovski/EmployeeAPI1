using EmployeeAPI1.Models;

namespace EmployeeAPI1.Repositories
{
    public interface IEmpRepository
    {
        Task<IEnumerable<Employee>> Get();
        Task<Employee> Get(int EmpId);
        Task<Employee> Create(Employee employee);
        Task Update(Employee employee);
        Task Delete(int EmpId);
    }
}
