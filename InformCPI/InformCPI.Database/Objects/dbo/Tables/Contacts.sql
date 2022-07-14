CREATE TABLE [dbo].[Contacts]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] VARCHAR(50) NULL, 
    [Email] VARCHAR(50) NULL, 
    [Address] VARCHAR(50) NULL, 
    [Phone] VARCHAR(50) NULL
)
