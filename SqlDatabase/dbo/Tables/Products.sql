CREATE TABLE [dbo].[Products] (
    [Productid]          INT            IDENTITY (1, 1) NOT NULL,
    [ProductName]        NVARCHAR (MAX) NOT NULL,
    [ProductDescription] NVARCHAR (MAX) NOT NULL,
    [QtyAvailable]       INT            NOT NULL,
    [UnitPrice]          FLOAT (53)     NOT NULL,
    [CategoryId]         INT            NOT NULL,
    [CreatedDate]        DATETIME2 (7)  NULL,
    [ModifiedDate]       DATETIME2 (7)  NULL,
    [Enabled]            BIT            NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Productid] ASC),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([CategoryId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId]
    ON [dbo].[Products]([CategoryId] ASC);

