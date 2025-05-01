using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjects;
using Demo.DataAccess.Models;

namespace Demo.BusinessLogic.Factories
{
    static class DepartmentFactory
    {
        #region ToDepartmentDetailsDTO
        public static DepartmentsDetailsDTO ToDepartmentDetailsDTO(this Department dept)
        {
            // this => mean object of class department call the function(DepartmentsDetailsDTO)
            return new DepartmentsDetailsDTO()
            {
                Id = dept.Id,
                Name = dept.Name,
                CreatedOn = DateOnly.FromDateTime(dept.CreatedOn),
                LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn)
                //all attributes
            };
        }
        #endregion

        #region ToDepartmentDTO
        public static DepartmentDTO ToDepartmentDTO(this Department dept)
        {
            return new DepartmentDTO()
            {
                DeptId = dept.Id,
                Name = dept.Name,
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
       public static Department ToEntity(this UpdateDepartmentDTO updeptdto)
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
