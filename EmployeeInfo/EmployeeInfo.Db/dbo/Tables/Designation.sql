CREATE TABLE [dbo].[Designation] (
    [Id]                     INT              IDENTITY (1, 1) NOT NULL,
    [DesignationName]        VARCHAR (50)     NULL,
    [DesignationDescription] VARCHAR (100)    NULL,
    [ModifiedBy]             UNIQUEIDENTIFIER NOT NULL,
    [ModifiedDate]           DATETIME         CONSTRAINT [DF_Designation_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Designation_User] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User] ([UserId])
);

