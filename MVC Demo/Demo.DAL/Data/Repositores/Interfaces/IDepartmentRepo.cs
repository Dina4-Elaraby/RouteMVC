using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositores.Interfaces
{
    internal interface IDepartmentRepo
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        int Update(Department dept);
        int Delete(Department row);
        int Insert(Department row);
    }
}
