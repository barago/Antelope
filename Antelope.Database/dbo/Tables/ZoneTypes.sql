CREATE TABLE [dbo].[ZoneTypes] (
    [ZoneTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [Nom]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.ZoneTypes] PRIMARY KEY CLUSTERED ([ZoneTypeId] ASC)
);

