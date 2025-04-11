using Demo.DAL.Data.Repositores.Interfaces;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositores.Classs
{
    internal class DepartmentRepo : IDepartmentRepo
    {
        private AppDbContext dbContext; //field ,default value => null
        public DepartmentRepo()
        {

        }
        public int Delete(Department row)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public Department GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Department row)
        {
            throw new NotImplementedException();
        }

        public int Update(Department dept)
        {
            throw new NotImplementedException();
        }
    }
}
