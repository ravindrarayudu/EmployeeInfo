CREATE TABLE [dbo].[Customer] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [CustomerName] VARCHAR (50)     NULL,
    [AddressId]    INT              NOT NULL,
    [ModifiedBy]   UNIQUEIDENTIFIER NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_Customer_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customer_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]),
    CONSTRAINT [FK_Customer_User] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User] ([UserId])
);

