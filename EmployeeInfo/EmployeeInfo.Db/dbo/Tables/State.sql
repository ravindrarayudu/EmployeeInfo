CREATE TABLE [dbo].[State] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [StateName]    VARCHAR (50)     NULL,
    [CountryId]    INT              NOT NULL,
    [ModifiedBy]   UNIQUEIDENTIFIER NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_State_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_State_Country] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country] ([Id]),
    CONSTRAINT [FK_State_User] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User] ([UserId])
);

