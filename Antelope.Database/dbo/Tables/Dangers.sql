﻿CREATE TABLE [dbo].[Dangers] (
    [DangerID] INT            IDENTITY (1, 1) NOT NULL,
    [Nom]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Dangers] PRIMARY KEY CLUSTERED ([DangerID] ASC)
);

