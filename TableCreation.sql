

Create Table dbo.Dept (DeptId Int Identity(1,1) Primary Key,
	DeptName Varchar(50) Not Null);


Create Table dbo.Employee (EmployeeId Int Identity(1,1) Primary Key,
FirstName Varchar(50),
LastName Varchar(50),
DOB DateTime, DeptId Int References Dept(DeptId));

	