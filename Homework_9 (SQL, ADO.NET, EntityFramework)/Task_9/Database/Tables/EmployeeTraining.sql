CREATE TABLE [dbo].[EmployeeTraining]
(
    [EmployeeId] UNIQUEIDENTIFIER 
        CONSTRAINT [FK_EmployeeTraining_Employee] FOREIGN KEY
        REFERENCES [dbo].[Employee]([Id]) ON DELETE CASCADE NOT NULL,
    [TrainingId] UNIQUEIDENTIFIER 
        CONSTRAINT [FK_EmployeeTraining_Training] FOREIGN KEY
        REFERENCES [dbo].[Training]([Id]) ON DELETE CASCADE NOT NULL,
    CONSTRAINT [PK_EmployeeTraining] PRIMARY KEY ([EmployeeId], [TrainingId])
);
GO

CREATE INDEX [IDX_dbo_EmployeeTraining_EmployeeId] ON [dbo].[EmployeeTraining]([EmployeeId]);
GO

CREATE INDEX [IDX_dbo_EmployeeTraining_TrainingId] ON [dbo].[EmployeeTraining]([TrainingId]);
GO