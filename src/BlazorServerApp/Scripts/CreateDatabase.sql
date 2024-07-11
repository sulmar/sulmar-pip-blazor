create database LeavesDb

GO


use LeavesDb

GO

create table Users(
	UserId int primary key identity(1,1),
	FirstName nvarchar(50) NOT NULL,
	LastName  nvarchar(50) NOT NULL	
)