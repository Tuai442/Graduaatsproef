CREATE TABLE [dbo].[Bedrijf]
(
	[Id] INT NOT NULL PRIMARY KEY
	/* public Bedrijf(string naam, string btw, string adres, string telefoon, string email)*/, 
    [naam] VARCHAR(50) NOT NULL, 
    [btwNummer] VARCHAR(50) NOT NULL, 
    [adres] VARCHAR(50) NOT NULL, 
    [telefoon] VARCHAR(50) NOT NULL, 
    [email] VARCHAR(50) NOT NULL
)
