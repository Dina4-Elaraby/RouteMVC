using Demo.DataAccess.Models.CommonModel;
using Demo.DataAccess.Models.EmployeeModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.Presentation.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        [Required(ErrorMessage = "Name isnot allow be empty!!")]
        [MaxLength(50, ErrorMessage = "Max Length of Name must be 50 characters")]
        [MinLength(5, ErrorMessage = "Min Length of Name must be 5 characters")]
        public string Name { get; set; } = null!;

        [Range(22, 40)]
        public int Age { get; set; }

        [RegularExpression("^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$", ErrorMessage = "Address must be in formate 123-street-city-country")]
        public string Address { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }


        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }

        public Gender Gender { get; set; }


        [Display(Name = "Emplyee Type")]
        public EmployeeType EmployeeType { get; set; }

        [Display (Name = "Department")]
        public int? DepartmentId { get; set; }

        public IFormFile? Image { get; set; }
    }
}
