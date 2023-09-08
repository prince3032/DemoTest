using DemoApplication.Data;
using DemoApplication.Interfaces;
using DemoApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                return employee;
            }
            return new Employee();
        }

        public List<Employee> GetEmployeeList()
        {
            return _context.Employees.ToList();
        }

        void IEmployeeRepository.Edit(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }
    }
}
