

Create Table dbo.Department (DepartmentId Int Identity(1,1) Primary Key,
	DepartmentName Varchar(50) Not Null);


Create Table dbo.Employee (EmployeeId Int Identity(1,1) Primary Key,
FirstName Varchar(50),
LastName Varchar(50),
DOB DateTime, DeptId Int References Department(DepartmentId));

	