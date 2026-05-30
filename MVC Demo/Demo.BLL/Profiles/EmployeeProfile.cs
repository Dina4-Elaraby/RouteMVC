using AutoMapper;
using Demo.BusinessLogic.DataTransferObjects.Employee;
using Demo.DataAccess.Models.EmployeeModel;

namespace Demo.BusinessLogic.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeesDTO>()
                 .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender))
                 .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                 .ForMember(dest => dest.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null));

            #region Map from Employee to EmployeeDetailsDTO
            CreateMap<Employee, EmployeeDetailsDTO>()
                    .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                    .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender))
                    .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                    .ForMember(dest => dest.CreatedOn, options => options.MapFrom(src => DateOnly.FromDateTime(src.CreatedOn)))
                    .ForMember(dest => dest.LastModifiedOn, options => options.MapFrom(src => DateOnly.FromDateTime(src.LastModifiedOn)))
                    .ForMember(dest => dest.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null))
                    .ForMember(dest => dest.Image, options => options.MapFrom(src => src.ImageName));


            #endregion

            CreateMap<CreatedEmployeeDTO, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));


            CreateMap<UpdatedEmployeeDTO, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

            
        }
    }
}
