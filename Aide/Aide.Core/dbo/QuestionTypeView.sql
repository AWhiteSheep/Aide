CREATE VIEW [dbo].[QuestionTypeView]
	AS SELECT q.IdentityKeyQuizz as 'Questionnaire dbo.ID', q.IdentityKey as 'Question dbo.ID', 
		q.Numero as 'N''o', t.Nom as 'Type de question', q.Question as 'Question', q.Points as 'Question points attribués' FROM Question q left join QuestionType t on q.IdentityKeyQuestionType = t.IdentityKey
