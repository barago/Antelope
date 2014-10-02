CREATE TABLE [dbo].[Personnes] (
    [PersonneId] INT              IDENTITY (1, 1) NOT NULL,
    [Nom]        NVARCHAR (MAX)   NULL,
    [Prenom]     NVARCHAR (MAX)   NULL,
    [Guid]       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.Personnes] PRIMARY KEY CLUSTERED ([PersonneId] ASC)
);
