CREATE TABLE [dbo].[Question]
(
	IdentityKey INT PRIMARY KEY IDENTITY(1,1),
	IdentityKeyQuizz INT not null FOREIGN KEY REFERENCES Quizz(IdentityKey) ON DELETE CASCADE,
	[Identity]
	[Points] int not null,
	Ordre int not null,
)
