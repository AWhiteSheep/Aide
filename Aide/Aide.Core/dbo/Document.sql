CREATE TABLE [dbo].[Document]
(
	[IdentityKey] INT PRIMARY KEY IDENTITY(1,1),
	[IdentityKeyMatiere] int not null foreign key references Matiere (IdentityKey),
	[IdentityKeyDocumentParent] INT FOREIGN KEY REFERENCES DOCUMENT([IdentityKey]) NULL,
	[Nom] NVARCHAR(max) not null,
	[DateCreation] DATE not null default GetDate(),
	[Administrateur] varchar(50) not null  FOREIGN KEY REFERENCES ADMINISTRATEUR(NoEmploye),
	[TypeDocument] INT not null FOREIGN KEY REFERENCES TYPE_DOCUMENT(Id),
	[DocumentPath] nvarchar(max)
)
