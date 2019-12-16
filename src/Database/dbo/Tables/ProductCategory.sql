CREATE TABLE [dbo].[ProductCategory] (
    [ProdCatId]    INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName] VARCHAR (250) NULL,
    CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED ([ProdCatId] ASC)
);

