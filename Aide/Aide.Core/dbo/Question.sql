CREATE TABLE [dbo].[Question]
(
	[IdentityKey] INT NOT NULL PRIMARY KEY identity(0,1),
	[IdentityKeyQuizz] int not null foreign key references Quizz (IdentityKey) on delete cascade,
	[IdentityKeyQuestionType] int foreign key references QuestionType (IdentityKey) on delete set null,
	[Numero] int,
	[Points] int not null default 1,
	[Question] text
)
