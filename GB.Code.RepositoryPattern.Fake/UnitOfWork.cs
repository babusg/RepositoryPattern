using GB.Code.RepositoryPattern.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Code.RepositoryPattern.Fake
{
    public class UnitOfWork : IUnitOfWork
    {
        private static EmployeeRepository _employeeRepository;
        private static DepartmentRepository _departmentRepository;

        public UnitOfWork()
        {

        }
        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (_departmentRepository == null)
                    _departmentRepository = new DepartmentRepository();
                return _departmentRepository;
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository();
                return _employeeRepository;
            }
        }

        public void Dispose()
        {
            //do nothing
        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
