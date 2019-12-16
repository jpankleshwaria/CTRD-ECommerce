-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateProduct] 
		@ProductId	INT,
		@ProdCatId	INT,
		@ProdName	VARCHAR(250),
		@ProdDescription	VARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON; 
		--VARIABLE DECLARATION
	DECLARE		@ErrorMessage	VARCHAR(4500);
	DECLARE		@ErrorSeverity	INT;  
	DECLARE		@ErrorState		INT;

	
	IF EXISTS (SELECT 1 FROM [Product] NOLOCK WHERE ProdName = @ProdName AND ProdCatId = @ProdCatId)
	BEGIN
		SELECT	@ErrorSeverity = 14, @ErrorState = 1,
				@ErrorMessage = CONCAT('[UNIQUE_KEY_CONFLICT]','Product with same category and name ', @ProdName ,' already exists');

		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END
	ELSE
	BEGIN
	BEGIN TRY
	UPDATE	[dbo].[Product]
	SET		[ProdCatId] = @ProdCatId, ProdName = @ProdName, ProdDescription = @ProdDescription
	WHERE	ProductId = @ProductId
	END TRY
	BEGIN CATCH
	

		SELECT	@ErrorMessage		= 'Error - ' + ERROR_PROCEDURE() + ': ' + ERROR_MESSAGE() + ', Line: ' + CONVERT(VARCHAR(20), ERROR_LINE())
				, @ErrorSeverity	= ERROR_SEVERITY() 
				, @ErrorState		= ERROR_STATE()

		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
	END
END