using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.DepartmentRepo
{
    //primary constructor
    //Repository => crud operations of department model(functions),No logic 
    public class DepartmentRepo(AppDbContext dbContext) : GenericRepo<Department>(dbContext),IDepartmentRepo
    {
        
    }
}
