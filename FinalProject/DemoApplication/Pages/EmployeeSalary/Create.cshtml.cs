using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoApplication.Data;
using Microsoft.EntityFrameworkCore;
using DemoApplication.Interfaces;
using DemoApplication.DTOs;
using AutoMapper;

namespace DemoApplication.Pages.EmployeeSalary
{
    public class CreateModel : PageModel
    {
        private readonly IEmployeeSalaryRepository employeeSalaryRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper _mapper;

        public CreateModel(IEmployeeSalaryRepository employeeSalaryRepository, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeSalaryRepository = employeeSalaryRepository;
            this.employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public List<SelectListItem> Items { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var employees = employeeRepository.GetEmployeeList();
            Items = employees.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.FirstName + " " + c.LastName }).ToList();
            return Page();
        }

        [BindProperty]
        public EmployeeSalaryCreateDTO EmployeeSalary { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || employeeSalaryRepository.GetAll() == null || EmployeeSalary == null)
            {
                return Page();
            }
            var salary = _mapper.Map<EmployeeSalaryCreateDTO,Models.EmployeeSalary>(EmployeeSalary);
            salary.CreatedDate = DateTime.Now;
            await employeeSalaryRepository.CreateAsync(salary);

            return RedirectToPage("/Employee/Index");
        }
    }
}
