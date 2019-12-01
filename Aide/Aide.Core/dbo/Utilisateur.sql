CREATE TABLE [dbo].[Utilisateur]
(
	[IdentityKey] nvarchar(100) primary key,
	[Id] nvarchar(60) unique not null,
	[IdentityKeyRole] int foreign key references [Role] (ID) on delete set null,
	[Email] nvarchar(100) unique,
	[Nom] nvarchar(max),
	[Prenom] nvarchar(max)
)
