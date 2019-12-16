CREATE TABLE [dbo].[ProductAttribute] (
    [ProductId]      BIGINT        NOT NULL,
    [AttributeId]    INT           NOT NULL,
    [AttributeValue] VARCHAR (250) NULL,
    [ProdAttrId]     INT           IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_ProductAttribute] PRIMARY KEY CLUSTERED ([ProdAttrId] ASC),
    CONSTRAINT [FK_ProductAttribute_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]),
    CONSTRAINT [FK_ProductAttribute_ProductAttributeLookup] FOREIGN KEY ([AttributeId]) REFERENCES [dbo].[ProductAttributeLookup] ([AttributeId]),
    CONSTRAINT [Unique_ProductAttribute] UNIQUE NONCLUSTERED ([ProductId] ASC, [AttributeId] ASC)
);







