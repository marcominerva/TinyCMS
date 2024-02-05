CREATE TABLE [dbo].[ContentPages] (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
    [SiteId]               UNIQUEIDENTIFIER NOT NULL,
    [Title]                NVARCHAR (256)   NOT NULL,
    [Url]                  NVARCHAR (256)   NOT NULL,
    [Content]              NVARCHAR (MAX)   NOT NULL,
    [CreationDate]         DATETIME         NOT NULL,
    [LastModificationDate] DATETIME         NULL,
    [IsPublished]          BIT              NOT NULL,
    [StyleSheetUrls]       NVARCHAR (MAX)   NULL,
    [StyleSheetContent]    NVARCHAR (MAX)   NULL
);
GO

ALTER TABLE [dbo].[ContentPages]
    ADD CONSTRAINT [PK_ContentPages] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

ALTER TABLE [dbo].[ContentPages]
    ADD CONSTRAINT [DF_ContentPages_Id] DEFAULT (newid()) FOR [Id];
GO

ALTER TABLE [dbo].[ContentPages]
    ADD CONSTRAINT [DF_ContentPages_CreationDate] DEFAULT (getutcdate()) FOR [CreationDate];
GO

ALTER TABLE [dbo].[ContentPages]
    ADD CONSTRAINT [DF_ContentPages_IsPublished] DEFAULT ((1)) FOR [IsPublished];
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_ContentPages_UniqueUrl]
    ON [dbo].[ContentPages]([SiteId] ASC, [Url] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_ContentPages]
    ON [dbo].[ContentPages]([Url] ASC);
GO

ALTER TABLE [dbo].[ContentPages]
    ADD CONSTRAINT [FK_ContentPages_Sites] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Sites] ([Id]);
GO

