﻿CREATE TABLE [dbo].[PosteDeTravailTypes] (
    [PosteDeTravailTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [Nom]                  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.PosteDeTravailTypes] PRIMARY KEY CLUSTERED ([PosteDeTravailTypeId] ASC)
);

