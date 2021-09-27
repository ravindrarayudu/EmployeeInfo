CREATE TABLE [dbo].[EmployeeCustomer] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [EmployeeId]   INT              NOT NULL,
    [CustomerId]   INT              NOT NULL,
    [ModifiedBy]   UNIQUEIDENTIFIER NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_EmployeeCustomer_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_EmployeeCustomer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EmployeeCustomer_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_EmployeeCustomer_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]),
    CONSTRAINT [FK_EmployeeCustomer_User] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User] ([UserId])
);

