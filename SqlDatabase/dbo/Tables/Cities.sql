CREATE TABLE [dbo].[Cities] (
    [CityId]          INT            IDENTITY (1, 1) NOT NULL,
    [CityName]        NVARCHAR (MAX) NOT NULL,
    [CityDescription] NVARCHAR (MAX) NOT NULL,
    [StateId]         INT            NOT NULL,
    [CreatedDate]     DATETIME2 (7)  NULL,
    [ModifiedDate]    DATETIME2 (7)  NULL,
    [Enabled]         BIT            NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([CityId] ASC),
    CONSTRAINT [FK_Cities_States_StateId] FOREIGN KEY ([StateId]) REFERENCES [dbo].[States] ([StateId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Cities_StateId]
    ON [dbo].[Cities]([StateId] ASC);

