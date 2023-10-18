CREATE TABLE [dbo].[Sites] (
    [Id]                UNIQUEIDENTIFIER CONSTRAINT [DF_Sites_Id] DEFAULT (newid()) NOT NULL,
    [Title]             NVARCHAR (255)   NOT NULL,
    [IsPublished]       BIT              CONSTRAINT [DF_Sites_IsPublished] DEFAULT ((1)) NOT NULL,
    [StyleSheetUrls]    NVARCHAR (MAX)   NULL,
    [StyleSheetContent] NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Sites] PRIMARY KEY CLUSTERED ([Id] ASC)
);