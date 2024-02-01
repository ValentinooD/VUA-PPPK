CREATE TABLE Person (
	IDPerson int primary key identity,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	Age int not null,
	Email nvarchar(30) not null,
	Picture varbinary(max) null
);
go

CREATE TABLE Student (
	PersonID int unique,
	GPA float,
	FOREIGN KEY (PersonID) REFERENCES Person(IDPerson)
);
go

CREATE TABLE Professor (
	PersonID int unique,
	Degree nvarchar(100),
	Salary float,
	FOREIGN KEY (PersonID) REFERENCES Person(IDPerson)
);
go

CREATE TABLE Employee (
	PersonID int unique,
	Degree nvarchar(100),
	Position nvarchar(100),
	Salary float,
	FOREIGN KEY (PersonID) REFERENCES Person(IDPerson)
);
go

---
CREATE TABLE Course (
	IDCourse int primary key identity,
	Name nvarchar(100),
	StartTime time,
	EndTime time,
	IDPerson int,
	FOREIGN KEY (IDPerson) REFERENCES Person(IDPerson)
);
go


-- procedures
CREATE OR ALTER PROC GetCourses
	@IDPerson int
AS
SELECT * FROM Course WHERE IDPerson=@IDPerson
GO

CREATE PROC AddCourse
	@Name nvarchar(50),
	@StartTime time,
	@EndTime time,
	@IDPerson int,
	@IDCourse INT OUTPUT
AS 
BEGIN
INSERT INTO Course VALUES (@Name, @StartTime, @EndTime, @IDPerson)
	SET @IDCourse = SCOPE_IDENTITY()
END
GO

CREATE OR ALTER PROC DeleteCourse
	@IDCourse int
AS
DELETE FROM Course WHERE IDCourse = @IDCourse
GO

CREATE PROC GetPeople
AS
SELECT * FROM Person
GO

CREATE PROC GetStudents
AS
SELECT * FROM Person as p inner join Student as s on p.IDPerson=s.PersonID
GO

CREATE PROC GetProfessors
AS
SELECT * FROM Person as p inner join Professor as pf on p.IDPerson=pf.PersonID
GO

CREATE PROC GetEmployees
AS
SELECT * FROM Person as p inner join Employee as e on p.IDPerson=e.PersonID
GO

CREATE PROC GetPerson
	@idPerson int
AS
SELECT * FROM Person WHERE IDPerson = @idPerson
GO

CREATE OR ALTER PROC DeletePerson
	@idPerson int
AS
DELETE FROM Course WHERE IDPerson = @idPerson
DELETE FROM Student WHERE PersonID = @idPerson
DELETE FROM Employee WHERE PersonID = @idPerson
DELETE FROM Professor WHERE PersonID = @idPerson
DELETE FROM Person WHERE IDPerson = @idPerson
GO

CREATE PROC AddPerson
	@firstname nvarchar(20),
	@lastname nvarchar(20),
	@age int,
	@email nvarchar(30),
	@picture varbinary(max),
	@idPerson INT OUTPUT
AS 
BEGIN
INSERT INTO Person VALUES (@firstname, @lastname, @age, @email, @picture)
	SET @idPerson = SCOPE_IDENTITY()
END
GO

CREATE PROC AddStudent
	@IDPerson int,
	@gpa float
AS 
BEGIN
	INSERT INTO Student(PersonID, GPA) VALUES (@IDPerson, @gpa)
END
GO

CREATE PROC AddProfessor
	@IDPerson int,
	@Salary float,
	@Degree nvarchar(100)
AS 
BEGIN
	INSERT INTO Professor(PersonID, Salary, Degree) VALUES (@IDPerson, @Salary, @Degree)
END
GO

CREATE PROC AddEmployee
	@IDPerson int,
	@Salary float,
	@Position nvarchar(100),
	@Degree nvarchar(100)
AS 
BEGIN
	INSERT INTO Employee(PersonID, Salary, Position, Degree) VALUES (@IDPerson, @Salary, @Position, @Degree)
END
GO

CREATE PROC UpdatePerson
	@firstname nvarchar(20),
	@lastname nvarchar(20),
	@age int,
	@email nvarchar(30),
	@picture varbinary(max),
	@idPerson int
AS
UPDATE Person SET 
		FirstName = @firstname,
		LastName = @lastname,
		Age = @age,
		Email = @email,
		Picture = @picture
	WHERE 
		IDPerson = @idPerson

