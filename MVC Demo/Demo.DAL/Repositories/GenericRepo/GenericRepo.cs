using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.CommonModel;
using Demo.DataAccess.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Update(Entity entity)
        {
            _dbContext.Set<Entity>().Update(entity);//update locally
            return _dbContext.SaveChanges();// return n_rows affected in DB
        }
        #endregion

        #region Delete
        public int Remove(Entity entity)
        {
            _dbContext.Set<Entity>().Remove(entity);
            return _dbContext.SaveChanges();
        }
        #endregion

        #region Insert
        public int Add(Entity entity)
        {
            _dbContext.Set<Entity>().Add(entity);
            return _dbContext.SaveChanges();
        }
        #endregion
    }
}
