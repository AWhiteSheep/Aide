CREATE VIEW [dbo].[QuizzMatiereView]
	AS SELECT q.IdentityKey as 'Identité', q.Titre as 'Nom', m.Titre as 'Matière', q.[Description] as 'Déscription' FROM Quizz q left join  [QuizzMatiere] m on q.IdentityKeyMatiere = m.IdentityKey
