using Demo.DataAccess.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Models.CommonModel;

namespace Demo.DataAccess.Data.Configrations.BaseEntityConfigs
{
    public class BaseEntityConfigurations<T> :IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("GETDATE()");//default value when add row and it is fixed, can set and reset
            builder.Property(d => d.LastModifiedOn).HasComputedColumnSql("GETDATE()"); //automatically calculated when i make edit in record annot set or reset 

        }
    }
}
