using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.CommonModel;
using System.Linq.Expressions;

namespace Demo.DataAccess.Repositories.GenericRepo
{
    public class GenericRepo<Entity>(AppDbContext _dbContext) : IGenericRepo<Entity> where Entity : BaseEntity
    {
        #region GetAll
        public IEnumerable<Entity> GetAll(bool withtracking = false)
        {
            if (withtracking)
                return _dbContext.Set<Entity>().Where(e => e.IsDeleted != true).ToList();//return all objects, where => soft delete => delete from interface and not delete whole from db
            else
                return _dbContext.Set<Entity>().Where(e => e.IsDeleted != true).AsNoTracking().ToList();

        }
        #endregion

        #region GetById
        public Entity? GetById(int id) => _dbContext.Set<Entity>().Find(id);
        #endregion

        #region Update
        public void Update(Entity entity)
        {
            _dbContext.Set<Entity>().Update(entity);//update locally
        }
        #endregion

        #region Delete
        public void Remove(Entity entity)
        {
            _dbContext.Set<Entity>().Remove(entity);
        }
        #endregion

        #region Insert
        public void Add(Entity entity)
        {
            _dbContext.Set<Entity>().Add(entity); // add locally
        }


        #endregion

        public IEnumerable<Entity> GetIEnumerable()
        {
            return _dbContext.Set<Entity>();
        }

        public IQueryable<Entity> GetIQueryable()
        {
            //return set<entity> as IQueryable inherit from IEnumerable so no error occur
            return _dbContext.Set<Entity>();
        }

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<Entity, TResult>> selector)
        {
            return _dbContext.Set<Entity>()
                 .Where(e => e.IsDeleted != true)
                 .Select(selector).ToList();
            //return ienumerable to avoid extend any thing 

        }

        public IEnumerable<Entity> GetAll(Expression<Func<Entity, bool>> predict)
        {
            return _dbContext.Set<Entity>()
                    .Where(predict)
                    .ToList();
        }
    }
}
