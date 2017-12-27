CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Email] NCHAR(25) NOT NULL, 
    [Password] NCHAR(25) NOT NULL, 
    [Age] INT NULL, 
    [Gender] NVARCHAR(10) NULL
)
