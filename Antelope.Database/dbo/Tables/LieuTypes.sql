CREATE TABLE [dbo].[LieuTypes] (
    [LieuTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [Nom]        NVARCHAR (MAX) NULL,
    [Rang] INT NULL, 
    CONSTRAINT [PK_dbo.LieuTypes] PRIMARY KEY CLUSTERED ([LieuTypeId] ASC)
);

