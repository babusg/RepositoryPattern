using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GB.Code.RepositoryPattern.Entities.ORM;
using GB.Code.RepositoryPattern.Managers;
using GB.Code.RepositoryPattern.Fake;
using System.Linq;
using System.Collections;
namespace GB.Code.RepositoryPattern.UnitTest
{
    [TestClass]
    public class EmployeeManagerTest
    {
        [TestMethod]
        public void Check_If_Id_Exists()
        {
            var unitOfWork = new UnitOfWork();
            var employeeManager = new EmployeeManager(unitOfWork);
            var employee = new Employee { FirstName="NewEmployee", LastName = "SomeLastName", DOB= DateTime.Now.AddYears(-20), CreatedBy="User", CreatedDate= DateTime.Now  };
            employee= employeeManager.SaveEmployee(employee);
            var retrievedEmployeeFromRepository = unitOfWork.EmployeeRepository.FindBy(x => x.FirstName == "NewEmployee").FirstOrDefault();

            Assert.IsNotNull(retrievedEmployeeFromRepository);


        }
    }
}
