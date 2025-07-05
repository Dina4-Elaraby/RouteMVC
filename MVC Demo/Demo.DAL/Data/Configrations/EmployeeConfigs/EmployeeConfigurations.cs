using Demo.DataAccess.Data.Configrations.BaseEntityConfigs;
using Demo.DataAccess.Models.CommonModel;
using Demo.DataAccess.Models.EmployeeModel;

namespace Demo.DataAccess.Data.Configrations.EmployeeConfigs
{
    public class EmployeeConfigurations : BaseEntityConfigurations<Employee>,IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("nvarchar(50)");
            builder.Property(e => e.Address).HasColumnType("nvarchar(100)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");
            builder.Property(e => e.Gender)
                   .HasConversion(gender => gender.ToString(), (stringGender) => (Gender)Enum.Parse(typeof(Gender), stringGender));
            // gender=> Gender in Employee ,now it is string, stringGender=>genderafterconvert to string => convert to enum from string
            builder.Property(e => e.EmployeeType).HasConversion(empType => empType.ToString(), (stringEmpType) => (EmployeeType)Enum.Parse(typeof(EmployeeType), stringEmpType));

            
            base.Configure(builder);
        }

        
    }
}
