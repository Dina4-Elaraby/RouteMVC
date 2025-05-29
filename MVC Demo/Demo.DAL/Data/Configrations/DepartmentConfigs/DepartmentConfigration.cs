using Demo.DataAccess.Data.Configrations.BaseEntityConfigs;
using Demo.DataAccess.Models.DepartmentModel;

namespace Demo.DataAccess.Data.Configrations.DepartmentConfigs
{
    internal class DepartmentConfigration : BaseEntityConfigurations<Department>,IEntityTypeConfiguration<Department>
    {
        //Hide the configuration out but using base.Configure(builder) now show 
        public new void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);//start 10 and  increment 10
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");
            base.Configure(builder);
            
        }
    }
}
