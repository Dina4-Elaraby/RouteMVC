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
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType));


            #region Map from Employee to EmployeeDetailsDTO
            CreateMap<Employee, EmployeeDetailsDTO>()
                    .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                    .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender))
                    .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                    .ForMember(dest => dest.CreatedOn, options => options.MapFrom(src => DateOnly.FromDateTime(src.CreatedOn)))
                    .ForMember(dest => dest.LastModifiedOn, options => options.MapFrom(src => DateOnly.FromDateTime(src.LastModifiedOn)));

            #endregion

            CreateMap<CreatedEmployeeDTO, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UpdatedEmployeeDTO, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
        }
    }
}
