using Demo.DataAccess.Models.CommonModel;
using System.Linq.Expressions;

namespace Demo.DataAccess.Repositories.GenericRepo
{
    public interface IGenericRepo<Entity> where Entity:BaseEntity  
    {
        void Add(Entity entity);
        IEnumerable<Entity> GetAll(bool WithTracking = false);
        Entity? GetById(int id);
        void Update(Entity entity);
        void Remove(Entity entity);
        //IEnumerable<Entity> GetIEnumerable();
        //IQueryable<Entity> GetIQueryable();
        IEnumerable<TResult>GetAll<TResult>(Expression<Func<Entity,TResult>>selector);
        //expression is represented condition of where anything serach by it not only search name return bool
        IEnumerable<Entity> GetAll(Expression<Func<Entity, bool>> predict);

    }
}
