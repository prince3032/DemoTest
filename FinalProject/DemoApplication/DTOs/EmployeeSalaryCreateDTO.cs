namespace DemoApplication.DTOs
{
    public class EmployeeSalaryCreateDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SalaryDate { get; set; }
        public decimal Amount { get; set; }
    }
}
