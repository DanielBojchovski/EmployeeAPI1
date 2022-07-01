using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI1.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
    }
}
