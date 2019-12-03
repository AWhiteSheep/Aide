/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/



INSERT INTO ADMINISTRATEUR VALUES('1234567', 'test@test.ca', 'Allo123', 'Groulx', 'Marika')
GO

INSERT INTO TYPE_DOCUMENT VALUES('Notes de cours'),('Exercice PDF'),('Exercice interactif'),('Corrigé')
GO

INSERT INTO CATEGORIE_DOCUMENT VALUES ('Synthaxe'),('Orthographe'),('Ponctuation'),('Vocabulaire'),('Autre')
GO

INSERT INTO CATEGORIE_EXERCICE VALUES ('trouee')
GO

INSERT INTO CODE_ERREUR VALUES 
('S1', 'Structure de base de la phrase', 1),('S4', 'Coordination et juxtaposition', 1),('S6', 'Choix du pronom', 1),('S7', 'Intégration des citations', 1),('S8', 'Choix du temps et du mode des verbes', 1),
('O2', 'Homophones', 2),('O4', 'Accord du nom, de l’adjectif et du déterminant', 2),('O5', 'Accord du verbe/Conjugaison', 2),('O6', 'Distinction entre les terminaisons –er, –é, –ez et –ai', 2),('O7', 'Accord du participe passé', 2),('O8', 'Choix du singulier ou du pluriel', 2),
('P1', 'Utilisation de la virgule avec avec «  »', 3),('P2', 'Utilisation de la virgule avec avec «  »', 3),('P3', 'Utilisation de la virgule avec « qui »', 3),('P4', 'Utilisation de la virgule avec avec «  »', 3),
('V2', 'Anglicismes', 4),
('A1', 'Utilisation d’Antidote', 5)
GO

INSERT INTO DOCUMENT VALUES('Notes de cours', GETDATE(), NULL, '1234567', 'O2', 1)
GO

INSERT INTO DOCUMENT VALUES('Exercice test', GETDATE(), 1, '1234567', 'O2', 2)
GO

INSERT INTO DOCUMENT VALUES('Corrigé test', GETDATE(), 2, '1234567', 'O2', 4)
GO

INSERT INTO DOCUMENT VALUES('Notes de cours 2', GETDATE(), NULL, '1234567', 'O2', 1)
GO
