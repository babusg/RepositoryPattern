using GB.Code.RepositoryPattern.Entities.ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Code.RepositoryPattern.ORM.Map
{
    public static class DepartmentMap
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().Property(e => e.DeptId);
            modelBuilder.Entity<Department>().Property(e => e.DeptName).IsUnicode(false);
        }
    }
}
