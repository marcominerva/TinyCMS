CREATE TABLE [dbo].[Sites] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [Title]             NVARCHAR (255)   NOT NULL,
    [LogoUrl]           NVARCHAR (255)   NULL,
    [ShowLogoOnly]      BIT              NOT NULL,
    [IsPublished]       BIT              NOT NULL,
    [StyleSheetUrls]    NVARCHAR (MAX)   NULL,
    [StyleSheetContent] NVARCHAR (MAX)   NULL
);
GO

ALTER TABLE [dbo].[Sites]
    ADD CONSTRAINT [PK_Sites] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

ALTER TABLE [dbo].[Sites]
    ADD CONSTRAINT [DF_Sites_ShowLogoOnly] DEFAULT ((0)) FOR [ShowLogoOnly];
GO

ALTER TABLE [dbo].[Sites]
    ADD CONSTRAINT [DF_Sites_Id] DEFAULT (newid()) FOR [Id];
GO

ALTER TABLE [dbo].[Sites]
    ADD CONSTRAINT [DF_Sites_IsPublished] DEFAULT ((1)) FOR [IsPublished];
GO

