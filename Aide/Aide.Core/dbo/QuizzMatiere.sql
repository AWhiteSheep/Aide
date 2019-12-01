CREATE TABLE [dbo].[QuizzMatiere]
(
	[IdentityKey] int primary key identity(0,1),
	[Titre] nvarchar(max) default 'sans nom' NOT NULL,
)
