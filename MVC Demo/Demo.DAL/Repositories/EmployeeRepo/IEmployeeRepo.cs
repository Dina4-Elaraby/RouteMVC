using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Repositories.GenericRepo;

namespace Demo.DataAccess.Repositories.EmployeeRepo
{
    //special for employee only
    public interface IEmployeeRepo:IGenericRepo<Employee>
    {

    }
}
