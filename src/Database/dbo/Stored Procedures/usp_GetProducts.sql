-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetProducts]
	@prodName	VARCHAR(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    If @prodName <> ''
	BEGIN
		SELECT Prod.ProductId,Prod.ProdName,Prod.ProdDescription,PCat.ProdCatId,PCat.CategoryName AS ProdCatName FROM Product Prod
		INNER JOIN [ProductCategory] PCat (NOLOCK) ON Prod.ProdCatId = PCat.ProdCatId
		WHERE		Prod.ProdName LIKE '%'+ @prodName +'%'
	END
	ELSE
	BEGIN
		SELECT Prod.ProductId,Prod.ProdName,Prod.ProdDescription,PCat.ProdCatId,PCat.CategoryName AS ProdCatName FROM Product Prod
		INNER JOIN [ProductCategory] PCat (NOLOCK) ON Prod.ProdCatId = PCat.ProdCatId
	END
END