CREATE TABLE [dbo].[Sites] (
    [Id]    UNIQUEIDENTIFIER CONSTRAINT [DF_Sites_Id] DEFAULT (newid()) NOT NULL,
    [Title] NVARCHAR (255)   NOT NULL,
    CONSTRAINT [PK_Sites] PRIMARY KEY CLUSTERED ([Id] ASC)
);