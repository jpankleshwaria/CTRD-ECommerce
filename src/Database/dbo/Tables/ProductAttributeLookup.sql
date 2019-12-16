CREATE TABLE [dbo].[ProductAttributeLookup] (
    [AttributeId]   INT           IDENTITY (1, 1) NOT NULL,
    [ProdCatId]     INT           NOT NULL,
    [AttributeName] VARCHAR (250) NOT NULL,
    CONSTRAINT [PK_ProductAttributeLookup] PRIMARY KEY CLUSTERED ([AttributeId] ASC),
    CONSTRAINT [FK_ProductAttributeLookup_ProductCategory] FOREIGN KEY ([ProdCatId]) REFERENCES [dbo].[ProductCategory] ([ProdCatId])
);

