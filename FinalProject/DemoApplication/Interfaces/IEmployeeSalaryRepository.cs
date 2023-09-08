using DemoApplication.Models;

namespace DemoApplication.Interfaces
{
    public interface IEmployeeSalaryRepository
    {
        Task CreateAsync(EmployeeSalary employeeSalary);
        List<EmployeeSalary> GetAll();
        List<EmployeeSalary> GetSalaryByEmployeeId(int id);
    }
}
