-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetProductAttributeById]
	@ProdId	INT,
	@AttrId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT ProdAttr.ProdAttrId,ProdAttr.ProductId,ProdAttr.AttributeId,ProdAttr.AttributeValue,Prod.ProdName,PAL.AttributeName,PC.CategoryName,PC.ProdCatId  FROM ProductAttribute ProdAttr
	LEFT JOIN Product Prod (NOLOCK) ON Prod.ProductId = ProdAttr.ProductId
	LEFT JOIN ProductAttributeLookup PAL (NOLOCK) ON PAL.AttributeId = ProdAttr.AttributeId
	LEFT JOIN ProductCategory PC (NOLOCK) ON PC.ProdCatId = Prod.ProdCatId
	WHERE		ProdAttr.ProductId = @ProdId AND ProdAttr.AttributeId = @AttrId
END