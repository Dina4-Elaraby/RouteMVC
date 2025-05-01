using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories;



namespace Demo.BusinessLogic.Services
{
    public class DepartmentServices(IDepartmentRepo _departmentRepo) : IDepartmentServices
    // injection , primary const
    {
        #region  Four Ways To Apply Mapping
        //1.Manual Mapping
        //2.Auto Mapper
        //3.Extension Methods
        //4.Constructor Mapping
        #endregion


        #region Get All Departments
        public IEnumerable<DepartmentDTO> GetAllDepts()
        {
            var depts = _departmentRepo.GetAll(); // return IEnumerable<department> exist in db

            #region MyRegion Manual mapping(Casting) from department to departmentdto
            // var deptstoreturn = depts.Select(d => new DepartmentDTO()
            //{
            //    DeptId = d.Id,
            //    Name = d.Name,
            //    Code = d.Code,
            //    Description = d.Description ?? " ",
            //    DateOfCreation = DateOnly.FromDateTime(d.CreatedOn),
            //});
            //return deptstoreturn; 
            #endregion

            #region Extension Methods
            var deptstoreturn = depts.Select(d => d.ToDepartmentDTO());
            return deptstoreturn;
            #endregion
        }
        #endregion

        #region Get Departments By Id
        public DepartmentsDetailsDTO? GetDepartmentsById(int id)
        {
            var depts = _departmentRepo.GetById(id); //return department,bur i wanna return departmentdetailsdto

            #region  One Way To Return Data From DepartmentsDetailsDTO(Manual Mapping
            //if (depts is null)
            //{ return null; }
            //else
            //{
            //    var deptstoreturn = new DepartmentsDetailsDTO()
            //    {
            //        Id = depts.Id,
            //        CreatedOn = DateOnly.FromDateTime(depts.CreatedOn),
            //        LastModifiedOn = DateOnly.FromDateTime(depts.LastModifiedOn)
            //        // and all attributes as it
            //    };

            //     return deptstoreturn;
            //} 
            #endregion

            #region second Way To Return Data From DepartmentsDetailsDTO
            // manual mapping=>create object of DepartmentsDetailsDTO and make initialize 
            //return depts is null ? null : new DepartmentsDetailsDTO()
            //{
            //    Id = depts.Id,
            //    CreatedOn = DateOnly.FromDateTime(depts.CreatedOn),
            //    LastModifiedOn = DateOnly.FromDateTime(depts.LastModifiedOn)

            //};
            #endregion

            #region Return Data By Constructor Mapping
            //return depts is null ? null : new DepartmentsDetailsDTO(depts);
            #endregion

            #region Return Data By Extension Methods
            //Create class static contain function static 
            return depts is null ? null : depts.ToDepartmentDetailsDTO();
            #endregion
        }
        #endregion

        #region Add New Department
        public int AddNewDepartment(CreatedDepartmentDTO deptdto)
        {
            var depts = deptdto.ToEntity(); //varible of Department object 
            return _departmentRepo.Add(depts);
        }
        #endregion

        #region Update Department
        public int UpdateDepartment(UpdateDepartmentDTO updeptdto)
        {
            //var dept = updeptdto.ToEntity(); //varible of Department object 
            //return _departmentRepo.Update(dept);

            //or
            return _departmentRepo.Update(updeptdto.ToEntity());
        }
        #endregion

        #region Delete Department
        public bool DeleteDepartment(int id)
        {
            var dept = _departmentRepo.GetById(id); // get id i wanna delete
            if (dept is null) return false;
            else
            {
                int result = _departmentRepo.Remove(dept);//remove id 
                return result > 0 ? true : false;
            }
        }
        #endregion
    }
}

