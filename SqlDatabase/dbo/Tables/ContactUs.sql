CREATE TABLE [dbo].[ContactUs] (
    [ContactUsId]  INT            IDENTITY (1, 1) NOT NULL,
    [Subject]      NVARCHAR (MAX) NOT NULL,
    [Message]      NVARCHAR (MAX) NOT NULL,
    [Email]        NVARCHAR (MAX) NOT NULL,
    [Phone]        NVARCHAR (MAX) NOT NULL,
    [FirstName]    NVARCHAR (MAX) NOT NULL,
    [LastName]     NVARCHAR (MAX) NOT NULL,
    [CreatedDate]  DATETIME2 (7)  NULL,
    [ModifiedDate] DATETIME2 (7)  NULL,
    [Enabled]      BIT            NOT NULL,
    CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED ([ContactUsId] ASC)
);

