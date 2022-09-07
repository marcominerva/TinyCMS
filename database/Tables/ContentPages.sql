CREATE TABLE [dbo].[ContentPages] (
    [Id]                   UNIQUEIDENTIFIER CONSTRAINT [DF_ContentPages_Id] DEFAULT (newid()) NOT NULL,
    [SiteId]               UNIQUEIDENTIFIER NOT NULL,
    [Title]                NVARCHAR (256)   NOT NULL,
    [Url]                  NVARCHAR (256)   NOT NULL,
    [Content]              NVARCHAR (MAX)   NOT NULL,
    [CreationDate]         DATETIME         CONSTRAINT [DF_ContentPages_CreationDate] DEFAULT (getutcdate()) NOT NULL,
    [LastModificationDate] DATETIME         NULL,
    [IsPublished]          BIT              CONSTRAINT [DF_ContentPages_IsPublished] DEFAULT ((1)) NOT NULL,
    [StyleSheetUrls]       NVARCHAR (MAX)   NULL,
    [StyleSheetContent]    NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_ContentPages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ContentPages_Sites] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Sites] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ContentPages]
    ON [dbo].[ContentPages]([Url] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ContentPages_UniqueUrl]
    ON [dbo].[ContentPages]([SiteId] ASC, [Url] ASC);

