CREATE TABLE [dbo].[QuestionReponse]
(
	[IdentityKey] INT NOT NULL PRIMARY KEY identity(0,1),
	[IdentityKeyQuestion] Int not null foreign key references Question (IdentityKey) on delete cascade,
	[No] int,
	[Bon] bit not null default 1,
	[Reponse] text
)
