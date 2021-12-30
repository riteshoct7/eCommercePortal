CREATE TABLE [dbo].[Countries] (
    [CountryId]          INT            IDENTITY (1, 1) NOT NULL,
    [CountryName]        NVARCHAR (MAX) NOT NULL,
    [CountryDescription] NVARCHAR (MAX) NOT NULL,
    [ISDCode]            NVARCHAR (MAX) NOT NULL,
    [CreatedDate]        DATETIME2 (7)  NULL,
    [ModifiedDate]       DATETIME2 (7)  NULL,
    [Enabled]            BIT            NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([CountryId] ASC)
);

