CREATE TABLE [dbo].[City] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [CityName]     VARCHAR (50)     NULL,
    [StateId]      INT              NOT NULL,
    [ModifiedBy]   UNIQUEIDENTIFIER NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_City_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_City_State] FOREIGN KEY ([StateId]) REFERENCES [dbo].[State] ([Id]),
    CONSTRAINT [FK_City_User] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User] ([UserId])
);

