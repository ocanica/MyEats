CREATE TABLE [dbo].[Postcodes] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [PostcodePrefix] VARCHAR (10)   NOT NULL,
    [Town]           NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Postcodes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

