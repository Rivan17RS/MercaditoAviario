CREATE TABLE [dbo].[PurchaseOrder] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Product]     VARCHAR (250)   NULL,
    [Quantity]    INT             NULL,
    [Price]       DECIMAL (18, 2) NULL,
    [BuyerPerson] VARCHAR (100)   NULL,
    [CompanyName] VARCHAR (100)   NULL,
    [Email]       VARCHAR (100)   NULL,
    [Phone]       VARCHAR (12)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

