CREATE TABLE [dbo].[Customers] (
    [CustomerId]     UNIQUEIDENTIFIER NOT NULL,
    [FirstName]      NVARCHAR (50)    NOT NULL,
    [LastName]       NVARCHAR (50)    NOT NULL,
    [Email]          VARCHAR (100)    NOT NULL,
    [Password]       VARCHAR (50)     NOT NULL,
    [PhoneNumber]    VARCHAR (50)     NOT NULL,
    [StreetAddress]  VARCHAR (150)    NOT NULL,
    [Town]           VARCHAR (150)    NOT NULL,
    [City]           VARCHAR (100)    NOT NULL,
    [Postcode]       VARCHAR (15)     NOT NULL,
    [DateRegistered] DATETIME2 (7)    NOT NULL,
    [PostcodeId]     INT              NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

