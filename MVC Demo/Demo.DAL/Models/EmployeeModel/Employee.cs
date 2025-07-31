using Demo.DataAccess.Models.CommonModel;
using Demo.DataAccess.Models.DepartmentModel;

namespace Demo.DataAccess.Models.EmployeeModel
{
    public class Employee:BaseEntity
    {
        public required string Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public decimal  Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int? DepartmentId { get; set; } //fk
        public virtual Department? Department { get; set; } //navigation property

        public string? ImageName { get; set; }
    }
}
