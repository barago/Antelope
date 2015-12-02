CREATE TABLE [dbo].[DialogueSecurites]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Date] DATETIME NOT NULL, 
    [Contexte] NVARCHAR(MAX) NOT NULL, 
    [Observation] NVARCHAR(MAX) NOT NULL, 
    [Reflexion] NVARCHAR(MAX) NOT NULL, 
    [Action] NVARCHAR(MAX) NOT NULL, 
    [Atelier] NCHAR(10) NOT NULL, 
    [SiteId] INT NOT NULL,
	[CompteurAnnuelSite] INT NOT NULL, 
    [Code] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_dbo.DialogueSecurites_dbo.Sites_SiteId] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Sites] ([SiteID]) ON DELETE CASCADE,
)
