CREATE TABLE [dbo].[UtilisateurQuestionReponse]
(
	[IdentityKey] nvarchar(100) NOT NULL PRIMARY KEY default NEWID(),
	[IdentityKeyUser] nvarchar(100) NOT NULL FOREIGN KEY REFERENCES UTILISATEUR (IdentityKey) on delete cascade,
	[IdentityKeyQuestionReponse] INT NOT NULL FOREIGN KEY REFERENCES QUESTION (IdentityKey) on delete cascade,
	[Essaie] INT NOT NULL identity(0,1),
	constraint essaie_unique unique([IdentityKeyUser], [IdentityKeyQuestionReponse], [Essaie])
)
