using GB.Code.RepositoryPattern.Contracts.Repositories;
using GB.Code.RepositoryPattern.Entities.ORM;
using GB.Code.RepositoryPattern.Fake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Code.RepositoryPattern.Fake
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(): base(e=> e.EmployeeId )
        {
            Entities.Add(new Employee { FirstName = "Ganesh", LastName = "xxx", DOB = DateTime.Now, DeptId = 1 });

        }
    }
}
