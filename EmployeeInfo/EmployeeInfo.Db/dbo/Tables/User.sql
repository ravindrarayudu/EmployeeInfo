CREATE TABLE [dbo].[User] (
    [UserId]           UNIQUEIDENTIFIER NOT NULL,
    [Phone]            NVARCHAR (50)    NOT NULL,
    [Fax]              NVARCHAR (50)    NULL,
    [ContactName]      NVARCHAR (50)    NULL,
    [UserName]         NVARCHAR (50)    NULL,
    [Password]         NVARCHAR (MAX)   NOT NULL,
    [IsForgotPassword] BIT              CONSTRAINT [DF_User_IsForgotPassword] DEFAULT ((0)) NULL,
    [LocationId]       INT              NULL,
    [CreatedBy]        UNIQUEIDENTIFIER NULL,
    [ModifiedDate]     DATETIME         CONSTRAINT [DF_User_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedBy]       UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

