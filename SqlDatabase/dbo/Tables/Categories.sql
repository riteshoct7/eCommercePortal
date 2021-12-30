CREATE TABLE [dbo].[Categories] (
    [CategoryId]          INT            IDENTITY (1, 1) NOT NULL,
    [CategoryName]        NVARCHAR (MAX) NOT NULL,
    [CategoryDescription] NVARCHAR (MAX) NOT NULL,
    [CreatedDate]         DATETIME2 (7)  NULL,
    [ModifiedDate]        DATETIME2 (7)  NULL,
    [Enabled]             BIT            NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

