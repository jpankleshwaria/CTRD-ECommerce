-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetProductById]
	@ProdId	INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT Prod.ProductId,Prod.ProdCatId,Prod.ProdName,Prod.ProdDescription,PCat.CategoryName AS ProdCatName FROM Product Prod
	INNER JOIN [ProductCategory] PCat (NOLOCK) ON Prod.ProdCatId = PCat.ProdCatId
	WHERE		Prod.ProductId = @ProdId
END