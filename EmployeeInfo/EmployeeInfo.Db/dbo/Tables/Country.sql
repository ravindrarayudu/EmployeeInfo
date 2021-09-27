CREATE TABLE [dbo].[Country] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [CountryName]  VARCHAR (50)     NULL,
    [ModifiedBy]   UNIQUEIDENTIFIER NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_Country_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Country_User] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User] ([UserId])
);

