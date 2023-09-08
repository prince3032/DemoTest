using AutoMapper;
using DemoApplication.DTOs;
using DemoApplication.Interfaces;
using DemoApplication.Repositories;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepository _repository;
        private readonly IEmployeeSalaryRepository _repositorySalary;
        private readonly ILogger<IndexModel> _logger;
        private readonly IMapper _mapper;

        public IndexModel(IEmployeeRepository repository, ILogger<IndexModel> logger, IMapper mapper, IEmployeeSalaryRepository repositorySalary)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _repositorySalary = repositorySalary;
        }

        public IList<Models.Employee> Employee { get; set; } = default!;

        public void OnGetAsync()
        {
            var employees = _repository.GetEmployeeList();
            if (employees != null)
            {
                Employee = employees;
            }
        }
        public IActionResult OnGetGetEditForm(int id)
        {
            var employee = _repository.GetEmployeeById(id);
            var employeeDTO = _mapper.Map<Models.Employee, EditEmployeeDTO>(employee);
            return Partial("_Edit", employeeDTO);
        }
        public IActionResult OnGetGetSalaries(int id)
        {
            var salaries = _repositorySalary.GetSalaryByEmployeeId(id);
            return Partial("_salaries", salaries);
        }
        public IActionResult OnPostEmpolyeeDetails(EditEmployeeDTO dto)
        {
            try
            {
                var employee = _mapper.Map<EditEmployeeDTO, Models.Employee>(dto);

                _repository.Edit(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return RedirectToAction("/Index");
        }
    }
}
