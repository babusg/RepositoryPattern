using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GB.Code.RepositoryPattern.Contracts;
using GB.Code.RepositoryPattern.Repositories;
using GB.Code.RepositoryPattern.Entities;
using GB.Code.RepositoryPattern.Entities.ORM;

namespace GB.Code.RepositoryPattern.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    db.DepartmentRepository.Add(new Department { DeptName = "HR" });
                    db.DepartmentRepository.Add(new Department { DeptName = "R & D" });
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
