CREATE TABLE [dbo].[Lieux] (
    [LieuID]     INT            IDENTITY (1, 1) NOT NULL,
    [ZoneId]     INT            NOT NULL,
    [LieuTypeId] INT            NOT NULL,
    [Nom]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Lieux] PRIMARY KEY CLUSTERED ([LieuID] ASC),
    CONSTRAINT [FK_dbo.Lieux_dbo.LieuTypes_LieuTypeId] FOREIGN KEY ([LieuTypeId]) REFERENCES [dbo].[LieuTypes] ([LieuTypeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Lieux_dbo.Zones_ZoneId] FOREIGN KEY ([ZoneId]) REFERENCES [dbo].[Zones] ([ZoneID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ZoneId]
    ON [dbo].[Lieux]([ZoneId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_LieuTypeId]
    ON [dbo].[Lieux]([LieuTypeId] ASC);

