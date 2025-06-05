using Demo.DataAccess.Models.CommonModel;
using System.Linq.Expressions;

namespace Demo.DataAccess.Repositories.GenericRepo
{
    public interface IGenericRepo<Entity> where Entity:BaseEntity  
    {
        int Add(Entity entity);
        IEnumerable<Entity> GetAll(bool WithTracking = false);
        Entity? GetById(int id);
        int Update(Entity entity);
        int Remove(Entity entity);
        //IEnumerable<Entity> GetIEnumerable();
        //IQueryable<Entity> GetIQueryable();
        IEnumerable<TResult>GetAll<TResult>(Expression<Func<Entity,TResult>>selector);

    }
}
