using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoApplication.DTOs
{
    public class EditEmployeeDTO
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(10)]
        public string Zip { get; set; }
    }
}
