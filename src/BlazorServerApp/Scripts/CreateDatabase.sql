create database LeavesDb

GO


use LeavesDb

GO

create table Users(
	UserId int primary key identity(1,1),
	FirstName nvarchar(50) NOT NULL,
	LastName  nvarchar(50) NOT NULL	
)

GO

CREATE TABLE Leaves(
    LeaveId int primary key identity(1,1),
    UserId int foreign key references dbo.Users(UserId),
    LeaveType smallint NOT NULL,
    DateFrom DATE NOT NULL,
    DateTo DATE NOT NULL,
	LeaveStatus smallint NOT NULL
)

GO