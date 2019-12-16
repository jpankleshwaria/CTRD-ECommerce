﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetProductAttributeLookupsByProdCatId]
	@ProdCatId	INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT PAL.AttributeId, PAL.ProdCatId, PAL.AttributeName, PC.CategoryName FROM ProductAttributeLookup PAL
	INNER JOIN ProductCategory PC (NOLOCK) ON PC.ProdCatId = PAL.ProdCatId
	WHERE PAL.ProdCatId = @ProdCatId
	Order BY PAL.ProdCatId
END