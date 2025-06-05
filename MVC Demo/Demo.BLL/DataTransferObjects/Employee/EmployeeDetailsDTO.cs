using System.ComponentModel.DataAnnotations;

namespace Demo.BusinessLogic.DataTransferObjects.Employee
{
    //Return  Id [PK],Name,Age,Address ,Is Active,Salary,Email,Phone Number,HiringDate Gender and EmployeeType =>get by id
    public class EmployeeDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
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

        public DateOnly HiringDate { get; set; }
        public string Gender { get; set; } = null!;

        [Display(Name = "Emplyee Type")]
        public string EmployeeType { get; set; } = null!;

        public int CreatedBy { get; set; } // user id 
        public DateOnly CreatedOn { get; set; } //when insert reccord 
        public int LastModifiedBy { get; set; } // user id 
        public DateOnly LastModifiedOn { get; set; } // when last update occur in record(automatically calculated)
      
    }
}
