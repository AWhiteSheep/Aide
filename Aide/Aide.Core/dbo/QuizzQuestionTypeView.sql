CREATE VIEW [dbo].[QuizzQuestionTypeView]
	AS SELECT z.Titre as 'Titre questionnaire', * FROM Quizz z left join (select * from QuestionTypeView) q on q.[Questionnaire dbo.ID] = z.IdentityKey
