using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using GB.Code.RepositoryPattern.Entities.ORM;
using GB.Code.RepositoryPattern.ORM.Map;

namespace GB.Code.RepositoryPattern.ORM
{
    public partial class DBModel : DbContext 
    {
        public DBModel() : base("name=PlayModel") { }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            EmployeeMap.Map(modelBuilder);
            DepartmentMap.Map(modelBuilder);
        }

    }
}
