CREATE TABLE [dbo].[Quizz]
(
	[IdentityKey] int primary key identity(0,1),
	[IdentityKeyMatiere] int foreign key references [QuizzMatiere] (IdentityKey) on delete set null,
	[Titre] nvarchar(100) default 'sans nom' NOT NULL,
	[Description] text
)
