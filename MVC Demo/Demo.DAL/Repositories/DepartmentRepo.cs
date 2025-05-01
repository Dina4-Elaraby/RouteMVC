using Demo.DataAccess.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories
{
    //primary constructor
    //Repository => crud operations of department model(functions),No logic 
    public class DepartmentRepo(AppDbContext dbContext) : IDepartmentRepo
    {
        private readonly AppDbContext _dbContext = dbContext; //private field not to allow anyone edit it

        #region GetAll
        public IEnumerable<Department> GetAll(bool withtracking = false)
        {
            if (withtracking)
                return _dbContext.Departments.ToList();//return all objects
            else
                return _dbContext.Departments.AsNoTracking().ToList();

        }
        #endregion

        #region GetById
        public Department? GetById(int id) => _dbContext.Departments.Find(id);
        #endregion

        #region Update
        public int Update(Department dept)
        {
            _dbContext.Departments.Update(dept);//update locally
            return _dbContext.SaveChanges();// return n_rows affected in DB
        }
        #endregion

        #region Delete
        public int Remove(Department dept)
        {
            _dbContext.Departments.Remove(dept);
            return _dbContext.SaveChanges();
        }
        #endregion

        #region Insert
        public int Add(Department dept)
        {
            _dbContext.Departments.Add(dept);
            return _dbContext.SaveChanges();
        }
        #endregion
    }
}
