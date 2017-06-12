using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GB.Code.RepositoryPattern.Entities.ORM;

namespace GB.Code.RepositoryPattern.Contracts.Repositories
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
    }
}
