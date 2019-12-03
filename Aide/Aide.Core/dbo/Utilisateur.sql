CREATE TABLE [dbo].[Utilisateur]
(
	[IdentityKey] nvarchar(100) primary key default NEWID(),
	[Id] nvarchar(60) unique not null,
	[Nom] nvarchar(max) not null,
	[Prenom] nvarchar(max) not null
)