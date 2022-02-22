CREATE TABLE [dbo].[Training]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [PK_Training] PRIMARY KEY,
    [Name] NVARCHAR(64) NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [Description] NVARCHAR(max) NULL,
    CONSTRAINT [CHK_Training_StartDate] CHECK (StartDate >= '2001-01-01'),
    CONSTRAINT [CHK_Training_EndDate] CHECK (EndDate >= StartDate)
)
