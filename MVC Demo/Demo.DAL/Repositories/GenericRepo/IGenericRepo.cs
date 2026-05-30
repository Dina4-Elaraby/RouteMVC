using Demo.DataAccess.Models.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.GenericRepo
{
    public interface IGenericRepo<Entity> where Entity:BaseEntity  
    {
        int Add(Entity entity);
        IEnumerable<Entity> GetAll(bool WithTracking = false);
        Entity? GetById(int id);
        int Update(Entity entity);
        int Remove(Entity entity);
    }
}
