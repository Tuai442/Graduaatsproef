CREATE TABLE [dbo].[Bezoeker]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [voornaam] VARCHAR(50) NOT NULL, 
    [achternaam] VARCHAR(50) NOT NULL, 
    [email] VARCHAR(50) NOT NULL, 
    [bedrijfId] INT NOT NULL, 
    [nummerplaat] VARCHAR(50) NOT NULL
)
