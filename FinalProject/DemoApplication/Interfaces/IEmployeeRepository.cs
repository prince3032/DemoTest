using DemoApplication.Models;

namespace DemoApplication.Interfaces
{
    public interface IEmployeeRepository
    {
        void Create(Employee employee);
        void Edit(Employee employee);
        Employee GetEmployeeById(int id);
        List<Employee> GetEmployeeList();
    }
}
