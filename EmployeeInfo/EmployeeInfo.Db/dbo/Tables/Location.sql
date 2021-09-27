CREATE TABLE [dbo].[Location] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [LocationName] VARCHAR (50)     NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_Location_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedBy]   UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Location_User] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User] ([UserId])
);

