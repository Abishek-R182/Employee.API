using System.ComponentModel.DataAnnotations;

namespace Employee.API.Data
{
    public class EmployeeData
    {
        
        public int Id { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage ="Age is Must")]
        public int EmployeeAge { get; set; }

        [Required]
        public string salary { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string state { get; set; }

        [Required]
        public string country { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public string PhoneNo { get; set; }
    }
}
