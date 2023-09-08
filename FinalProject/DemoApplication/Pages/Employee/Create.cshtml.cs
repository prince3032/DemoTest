using DemoApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoApplication.Pages.Employee
{
    public class CreateModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<IndexModel> _logger;

        public CreateModel(IEmployeeRepository employeeRepository, ILogger<IndexModel> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Employee Employee { get; set; } = default!;

        public IActionResult OnPost()
        {
            try
            {
                if (!ModelState.IsValid || _employeeRepository.GetEmployeeList() == null || Employee == null)
                {
                    return Page();
                }
                Employee.CreatedDate = DateTime.Now;
                _employeeRepository.Create(Employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return RedirectToPage("./Index");
        }
    }
}
