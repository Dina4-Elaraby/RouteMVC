
namespace Demo.BusinessLogic.DataTransferObjects.Department
{
    public class DepartmentsDTO
    {
        //properties i wanna return ,may name attributes with not same names in database
        public int DeptId { get; set; }
        public string Name { get; set; } = string.Empty!;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; }
        public DateOnly DateOfCreation { get; set; }
    }
}
