CREATE DATABASE Task03

CREATE TABLE Directory
(
	IDDirectory int primary key identity,
	Name nvarchar(100)
)

CREATE TABLE Storage
(
	IDFile int primary key identity,
	IDDirectory int,
	FileName nvarchar(100),
	ContentType nvarchar(50),
	DateCreated smalldatetime,
	Data varbinary(max),
	FOREIGN KEY (IDDirectory) REFERENCES Directory(IDDirectory)
)

CREATE OR ALTER PROC GetPictures
AS
	SELECT * FROM Directory as d LEFT OUTER JOIN Storage as s on d.IDDirectory=s.IDDirectory
GO

CREATE OR ALTER PROC GetDirectories
as
	select * from Directory
go

CREATE OR ALTER PROC AddPicture
(
	@FileName nvarchar(100),
	@ContentType nvarchar(50),
	@DateCreated smalldatetime,
	@Data varbinary(max),
	@IDFile int output
)
AS
	INSERT INTO Storage(FileName, ContentType, DateCreated, Data)
		VALUES (@FileName, @ContentType, @DateCreated, @Data)
	SET @IDFile = SCOPE_IDENTITY()
GO

CREATE OR ALTER PROC GetDirectories
AS
	SELECT * FROM Directory
go

CREATE OR ALTER PROC GetDirectory
(
	@Name nvarchar(50),
	@IDDirectory int output
)
AS
	SET @IDDirectory=(SELECT TOP 1 IDDirectory from Directory WHERE Name=@Name)
go

CREATE OR ALTER PROC AddDirectory
(
	@Name nvarchar(50),
	@IDDirectory int output
)
AS
	IF NOT EXISTS(SELECT * FROM Directory WHERE Name=@Name)
	begin
		INSERT INTO Directory(Name) VALUES (@Name)
		SET @IDDirectory=SCOPE_IDENTITY()
	end
	else
		SET @IDDirectory=(SELECT TOP 1 IDDirectory from Directory WHERE Name=@Name)
GO

CREATE OR ALTER PROC InsertIntoDirectory
(
	@IDDirectory int,
	@IDFile	int
)
AS
	UPDATE Storage SET IDDirectory=@IDDirectory WHERE IDFile=@IDFile
go

CREATE OR ALTER PROC DeletePicture
(
	@IDFile int
)
AS
	DELETE FROM Storage WHERE IDFile=@IDFile
go

EXEC GetPictures
