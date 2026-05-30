using System.ComponentModel.DataAnnotations;

namespace Demo.BusinessLogic.DataTransferObjects.Employee
{
    //Return  Id [PK] , Name , Age ,  Is Active, Salary , Email , Gender and EmployeeType => get all
    public class EmployeesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string Gender { get; set; } = null!;

        [Display(Name="Emplyee Type")]
        public string EmployeeType { get; set; } = null!;

        public string? Department { get; set; }
    }
}
