CREATE TABLE [dbo].[PosteDeTravails] (
    [PosteDeTravailId]     INT IDENTITY (1, 1) NOT NULL,
    [ZoneId]               INT NOT NULL,
    [PosteDeTravailTypeId] INT NOT NULL,
    CONSTRAINT [PK_dbo.PosteDeTravails] PRIMARY KEY CLUSTERED ([PosteDeTravailId] ASC),
    CONSTRAINT [FK_dbo.PosteDeTravails_dbo.PosteDeTravailTypes_PosteDeTravailTypeId] FOREIGN KEY ([PosteDeTravailTypeId]) REFERENCES [dbo].[PosteDeTravailTypes] ([PosteDeTravailTypeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.PosteDeTravails_dbo.Zones_ZoneId] FOREIGN KEY ([ZoneId]) REFERENCES [dbo].[Zones] ([ZoneID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ZoneId]
    ON [dbo].[PosteDeTravails]([ZoneId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PosteDeTravailTypeId]
    ON [dbo].[PosteDeTravails]([PosteDeTravailTypeId] ASC);

