using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GB.Code.RepositoryPattern.Contracts.Repositories;
using GB.Code.RepositoryPattern.Entities;
using GB.Code.RepositoryPattern.Entities.ORM;

namespace GB.Code.RepositoryPattern.Managers
{
    public class EmployeeManager
    {
        private IUnitOfWork unitOfWork;
        public EmployeeManager(IUnitOfWork db)
        {
            unitOfWork = db;
        }

        public Employee SaveEmployee(Employee employee)
        {
            unitOfWork.EmployeeRepository.Add(employee);
            unitOfWork.SaveChanges();
            return employee;
        }
    }
}
