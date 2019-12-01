CREATE VIEW [dbo].[UtilisateurRoleView]
	AS SELECT u.IdentityKey as 'Utilisateur dbo.ID', u.Id as 'N''o utilisateur', r.ID as 'N''o role', r.Tag as 'Role tag', u.Prenom, u.Nom, u.Email as 'Addresse email' FROM Utilisateur u left join [Role] r on u.IdentityKeyRole = r.ID
