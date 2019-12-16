CREATE TABLE [dbo].[Product] (
    [ProductId]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [ProdCatId]       INT           NOT NULL,
    [ProdName]        VARCHAR (250) NOT NULL,
    [ProdDescription] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY ([ProdCatId]) REFERENCES [dbo].[ProductCategory] ([ProdCatId]),
    CONSTRAINT [Unique_Product] UNIQUE NONCLUSTERED ([ProdCatId] ASC, [ProdName] ASC)
);



