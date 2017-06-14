using GB.Code.RepositoryPattern.Contracts.Repositories;
using GB.Code.RepositoryPattern.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Code.RepositoryPattern.Repositories
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private DBModel dbContext;

        private IEmployeeRepository _employeeRepository;
        private IDepartmentRepository _departmentRepository;

        public UnitOfWork()
        {
            try
            {
                //dbContext = new DBModel(DALUtils.GetOracleConnection(), true);
                dbContext = new DBModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //dbContext = new CollineILModel(oraConn, true);

            //if (PrintEFQueriesToLog)
            //{
            //    var log = Logger.GetLogger("EFQueries");
            //    dbContext.Database.Log = l => log.Info(l);
            //}
        }

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (_departmentRepository == null)
                    _departmentRepository = new DepartmentRepository(dbContext);
                return _departmentRepository;
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(dbContext);
                return _employeeRepository;
            }
        }

        public Task<int> SaveChangesAsync()
        {
           return dbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
