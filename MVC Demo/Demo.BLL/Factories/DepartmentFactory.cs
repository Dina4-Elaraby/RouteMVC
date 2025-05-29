using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjects.Department;
using Demo.DataAccess.Models.DepartmentModel;

namespace Demo.BusinessLogic.Factories
{
    static class DepartmentFactory
    {
        #region ToDepartmentDetailsDTO
        public static DepartmentDetailsDTO ToDepartmentDetailsDTO(this Department dept)
        {
            // this => mean object of class department call the function(DepartmentsDetailsDTO)
            return new DepartmentDetailsDTO()
            {
                Id = dept.Id,
                Name = dept.Name,
                Code = dept.Code,
                Description = dept.Description,
                CreatedOn = DateOnly.FromDateTime(dept.CreatedOn),
                LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn)
                //all attributes
            };
        }
        #endregion

        #region ToDepartmentDTO
        public static DepartmentsDTO ToDepartmentDTO(this Department dept)
        {
            return new DepartmentsDTO()
            {
                DeptId = dept.Id,
                Name = dept.Name,
                Code = dept.Code,
                Description = dept.Description,
                DateOfCreation =DateOnly.FromDateTime( dept.CreatedOn)
            };
        }
        #endregion

        #region ToDepartment(Create)
        public static Department ToEntity(this CreatedDepartmentDTO DeptDto)
        {
            // convert from CreatedDepartmentDTO to Department
            return new Department()
            {
                Name = DeptDto.Name,
                Code = DeptDto.Code,
                Description = DeptDto.Description,
                CreatedOn = DeptDto.DateOfCreation.ToDateTime(new TimeOnly())
                //DateTime          DateOnly       convert to DateTime
            };
        }
        #endregion

        #region ToDepartment(Update)
       public static Department ToEntity(this UpdatedDepartmentDTO updeptdto)
        {
            return new Department()
            {
                Id = updeptdto.Id,
                Name = updeptdto.Name,
                Code = updeptdto.Code,
                Description = updeptdto.Description,
                CreatedOn = updeptdto.DateOfCreation.ToDateTime(new TimeOnly())

            };
        }
        #endregion

}
}
