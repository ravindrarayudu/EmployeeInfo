CREATE TABLE [dbo].[Address] (
    [Id]                 INT              IDENTITY (1, 1) NOT NULL,
    [AddressDescription] VARCHAR (50)     NULL,
    [AddressLineOne]     VARCHAR (50)     NULL,
    [CityId]             INT              NOT NULL,
    [LandMark]           VARCHAR (100)    NULL,
    [ModifiedDate]       DATETIME         CONSTRAINT [DF_Address_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedBy]         UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Address_City] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City] ([Id]),
    CONSTRAINT [FK_Address_User] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User] ([UserId])
);

