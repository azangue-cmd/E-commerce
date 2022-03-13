CREATE TABLE [dbo].[User] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (50)   NOT NULL,
    [Password] VARBINARY (100) NOT NULL,
    [Fullname] NVARCHAR (50)   NOT NULL,
    [Role]     VARBINARY (50)  NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [IX_User] UNIQUE NONCLUSTERED ([Username] ASC)
);

