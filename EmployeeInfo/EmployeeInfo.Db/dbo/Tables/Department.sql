CREATE TABLE [dbo].[Department] (
    [Id]             INT              IDENTITY (1, 1) NOT NULL,
    [DepartmentName] VARCHAR (50)     NULL,
    [Description]    VARCHAR (50)     NULL,
    [ModifiedBy]     UNIQUEIDENTIFIER NOT NULL,
    [ModifiedDate]   DATETIME         CONSTRAINT [DF_Department_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Department_User] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User] ([UserId])
);

