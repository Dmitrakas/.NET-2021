CREATE TABLE [dbo].[Vacation]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [PK_Vacation] PRIMARY KEY,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [EmployeeId] UNIQUEIDENTIFIER 
        CONSTRAINT [FK_Vacation_Employee] FOREIGN KEY (EmployeeId) REFERENCES Employee(Id) ON DELETE CASCADE NOT NULL,
    CONSTRAINT [CHK_Vacation_StartDate] CHECK (StartDate >= '2001-01-01'),
    CONSTRAINT [CHK_Vacation_EndDate] CHECK (EndDate >= StartDate)
);
GO

CREATE INDEX [IDX_dbo_Vacation_EmployeeId] ON [dbo].[Vacation]([EmployeeId]);
GO
