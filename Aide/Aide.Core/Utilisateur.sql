CREATE TABLE [dbo].[Utilisateur]
(
	[IdentityKey] int primary key identity(0,1),
	[Id] nvarchar(60) unique not null,
	[IdentityKeyRole] int foreign key references [Role] (ID) on delete set null,
	[Email] nvarchar(max) unique,
	[Nom] nvarchar(max),
	[Prenom] nvarchar(max)
)
