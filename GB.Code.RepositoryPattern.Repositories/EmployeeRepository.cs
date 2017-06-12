using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GB.Code.RepositoryPattern.Contracts;
using GB.Code.RepositoryPattern.Entities.ORM;
using GB.Code.RepositoryPattern.Contracts.Repositories;
using GB.Code.RepositoryPattern.ORM;

namespace GB.Code.RepositoryPattern.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DBModel dbContext) : base(dbContext)
        {
        }
    }
}
