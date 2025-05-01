namespace Demo.DataAccess.Data.Configrations
{

    internal class DepartmentConfigration : IEntityTypeConfiguration<Department>

    
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);//start 10 and  increment 10
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("GETDATE()");//default value when add row and it is fixed, can set and reset
            builder.Property(d => d.LastModifiedOn).HasComputedColumnSql("GETDATE()"); //automatically calculated when i make edit in record annot set or reset 
            
        }
    }
}
