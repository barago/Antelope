CREATE TABLE [dbo].[ServiceTypes] (
    [ServiceTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [Nom]           NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.ServiceTypes] PRIMARY KEY CLUSTERED ([ServiceTypeId] ASC)
);

