CREATE TABLE [dbo].[CodeHelper]
(
	IdentityKey int identity(0,1),
	Code NVARCHAR(50) not null,
	IdentityKeyCodeCategory INT not null FOREIGN KEY REFERENCES CodeCategory([IdentityKey]),
	Nom NVARCHAR(MAX) not null,
	constraint key_helper_category unique (Code, IdentityKeyCodeCategory)
)
