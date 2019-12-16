-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetProductAttributes]
	@searchVal	VARCHAR(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    If @searchVal <> ''
	BEGIN
		SELECT ProdAttr.ProdAttrId,ProdAttr.ProductId,ProdAttr.AttributeId,ProdAttr.AttributeValue,Prod.ProdName,PAL.AttributeName,PC.CategoryName  FROM ProductAttribute ProdAttr
		LEFT JOIN Product Prod (NOLOCK) ON Prod.ProductId = ProdAttr.ProductId
		LEFT JOIN ProductAttributeLookup PAL (NOLOCK) ON PAL.AttributeId = ProdAttr.AttributeId
		LEFT JOIN ProductCategory PC (NOLOCK) ON PC.ProdCatId = Prod.ProdCatId
		WHERE		ProdAttr.AttributeValue LIKE '%'+ @searchVal +'%' OR Prod.ProdName LIKE '%'+ @searchVal +'%' OR PAL.AttributeName LIKE '%'+ @searchVal +'%'
	END
	ELSE
	BEGIN
		SELECT ProdAttr.ProdAttrId,ProdAttr.ProductId,ProdAttr.AttributeId,ProdAttr.AttributeValue,Prod.ProdName,PAL.AttributeName,PC.CategoryName  FROM ProductAttribute ProdAttr
		INNER JOIN [Product] Prod (NOLOCK) ON Prod.ProductId = ProdAttr.ProductId
		INNER JOIN [ProductAttributeLookup] PAL (NOLOCK) ON ProdAttr.AttributeId = PAL.AttributeId
		INNER JOIN [ProductCategory] PC (NOLOCK) ON Prod.ProdCatId = PC.ProdCatId
	END
END