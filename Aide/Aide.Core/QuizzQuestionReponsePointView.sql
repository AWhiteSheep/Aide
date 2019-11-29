CREATE VIEW [dbo].[QuizzQuestionReponsePointView]
	AS SELECT z.[Questionnaire dbo.ID],  z.[Titre questionnaire], z.[Question dbo.ID], 
		z.[N'o] as 'Question N''o', z.Question, z.[Question points attribués], r.IdentityKey as 'Réponse dbo.ID', r.Reponse as 'Reponse', r.Bon as 'Bonne/Mauvaise'
		FROM QuizzQuestionTypeView z left join QuestionReponse r on z.[Question dbo.ID] = r.IdentityKeyQuestion
