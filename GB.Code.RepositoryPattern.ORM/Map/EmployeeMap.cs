using GB.Code.RepositoryPattern.Entities.ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Code.RepositoryPattern.ORM.Map
{
    public static class EmployeeMap
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(e => e.EmployeeId);
            modelBuilder.Entity<Employee>().Property(e => e.FirstName).IsUnicode(false);
            modelBuilder.Entity<Employee>().Property(e => e.LastName).IsUnicode(false);
            modelBuilder.Entity<Employee>().Property(e => e.DOB);
            modelBuilder.Entity<Employee>().Property(e => e.DeptId);
        }
    }
}
