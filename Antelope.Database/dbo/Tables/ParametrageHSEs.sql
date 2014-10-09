CREATE TABLE [dbo].[ParametrageHSEs]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [EmailDiffusionFS] NVARCHAR(50) NULL, 
    [EmailRejetPlanActionFS] NVARCHAR(50) NULL
)
