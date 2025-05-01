using Demo.DataAccess.Models;

namespace Demo.BusinessLogic.DataTransferObjects
{
  public class DepartmentsDetailsDTO
    {
        #region Constructor Mapping
        //public DepartmentsDetailsDTO(Department dept)
        //{
        //    Id = dept.Id;
        //    CreatedOn = DateOnly.FromDateTime(dept.CreatedOn);
        //} 
        #endregion
        public int Id { get; set; } //pk
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public int CreatedBy { get; set; } // user id 
        public DateOnly CreatedOn { get; set; } //when insert reccord 
        public int LastModifiedBy { get; set; } // user id 
        public DateOnly LastModifiedOn { get; set; } // when last update occur in record(automatically calculated)
        public bool IsDeleted { get; set; }
    }
}
