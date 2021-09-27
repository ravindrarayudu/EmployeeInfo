CREATE TABLE [dbo].[BankDetails] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [BankName]     VARCHAR (50)     NULL,
    [IFSCCode]     VARCHAR (50)     NULL,
    [BranchName]   VARCHAR (50)     NULL,
    [ModifiedBy]   UNIQUEIDENTIFIER NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_BankDetails_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_BankDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BankDetails_User] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User] ([UserId])
);

