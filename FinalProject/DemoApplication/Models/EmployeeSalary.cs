using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApplication.Models
{
    public class EmployeeSalary
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SalaryDate { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public Employee Employee { get; set; }
    }
}
