-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateProductAttribute] 
		@ProdAttrId INT,
		@ProductId	INT,
		@AttributeId	INT,
		@AttributeValue	VARCHAR(250)
AS
BEGIN
	SET NOCOUNT ON; 
		--VARIABLE DECLARATION
	DECLARE		@ErrorMessage	VARCHAR(4500);
	DECLARE		@ErrorSeverity	INT;  
	DECLARE		@ErrorState		INT;

	
	IF EXISTS (SELECT 1 FROM [ProductAttribute] NOLOCK WHERE ProductId = @ProductId AND AttributeId = @AttributeId AND ProdAttrId = @ProdAttrId)
		BEGIN
		BEGIN TRY
		UPDATE	[dbo].[ProductAttribute]
		SET		[AttributeValue] = @AttributeValue
		WHERE	ProductId = @ProductId AND AttributeId = @AttributeId AND ProdAttrId = @ProdAttrId
		END TRY
		BEGIN CATCH
	

			SELECT	@ErrorMessage		= 'Error - ' + ERROR_PROCEDURE() + ': ' + ERROR_MESSAGE() + ', Line: ' + CONVERT(VARCHAR(20), ERROR_LINE())
					, @ErrorSeverity	= ERROR_SEVERITY() 
					, @ErrorState		= ERROR_STATE()

			RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
		END CATCH
	END
	ELSE
	BEGIN
		SELECT	@ErrorSeverity = 14, @ErrorState = 1,
				@ErrorMessage = 'Product with attribute does not exists';

		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END
END