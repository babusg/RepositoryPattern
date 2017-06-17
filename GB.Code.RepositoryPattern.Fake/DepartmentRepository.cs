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
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {

        public DepartmentRepository() : base(e => e.DeptId)
        {
            Entities.Add(new Department { DeptId = 1, DeptName = "R&D" });
            Entities.Add(new Department { DeptId = 2, DeptName = "HR" });

        }
    }
}
