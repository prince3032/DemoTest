using DemoApplication.Data;
using DemoApplication.Interfaces;
using DemoApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Repositories
{
    public class EmployeeSalaryRepository: IEmployeeSalaryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeSalaryRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task CreateAsync(EmployeeSalary employeeSalary)
        {
            _applicationDbContext.EmployeeSalaries.Add(employeeSalary);
            await _applicationDbContext.SaveChangesAsync();
        }

        public List<EmployeeSalary> GetAll()
        {
            var salarieslist = _applicationDbContext.EmployeeSalaries.ToList();
            return salarieslist;
        }
        public List<EmployeeSalary> GetSalaryByEmployeeId(int id)
        {
            var salarieslist = _applicationDbContext.EmployeeSalaries.Where(c=>c.EmployeeId == id).ToList();
            return salarieslist;
        }
    }
}
