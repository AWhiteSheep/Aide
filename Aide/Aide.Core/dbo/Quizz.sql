CREATE TABLE [dbo].[Quizz]
(
	[IdentityKey] int primary key identity(0,1),
	[IdentityDocument] INT not null FOREIGN KEY REFERENCES DOCUMENT([IdentityKey]) ON DELETE CASCADE,	
	[Titre] nvarchar(100) NOT NULL,
	[Description] text not null,
	[PointTotal] decimal(16,2)
)
