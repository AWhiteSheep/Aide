CREATE TABLE [dbo].[QuestionReponse]
(
	[IdentityKey] INT NOT NULL PRIMARY KEY identity(0,1),
	[IdentityKeyQuestion] Int not null foreign key references Question (IdentityKey) on delete cascade,
	[Ordre] int not null,
	[Reponse] INT null foreign key references QuestionReponse (IdentityKey),
	[Choix] text not null,
	[Explication] nvarchar(max) not null
)
