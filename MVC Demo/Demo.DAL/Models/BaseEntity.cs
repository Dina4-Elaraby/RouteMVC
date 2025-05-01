namespace Demo.DataAccess.Models
{
    public class BaseEntity
    {
        //common attributes for each entity
        public int Id { get; set; } //pk
        public int CreatedBy  { get; set; } // user id 
        public DateTime CreatedOn { get; set; } //when insert reccord 
        public int LastModifiedBy { get; set; } // user id 
        public DateTime LastModifiedOn { get; set; } // when last update occur in record(automatically calculated)
        public bool IsDeleted { get; set; } //soft delete ,true => exist in DB but i cannot interact with it, false => isnot exist in DB 
    }
}
