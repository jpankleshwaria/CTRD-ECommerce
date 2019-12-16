CREATE PROCEDURE [dbo].[usp_AddProductAttribute]
		@ProdAttrId INT OUT,
		@ProductId	INT,
		@AttributeId	INT,
		@AttributeValue	VARCHAR(250)
AS
BEGIN

	SET NOCOUNT ON;
		DECLARE		@ErrorMessage	VARCHAR(4500);
		DECLARE		@ErrorSeverity	INT;  
		DECLARE		@ErrorState		INT;  
	IF EXISTS(SELECT 1 FROM [ProductAttribute] (NOLOCK) WHERE ProductId = @ProductId AND AttributeId = @AttributeId)
	BEGIN
		SELECT	@ErrorSeverity = 14, @ErrorState = 1,
				@ErrorMessage = CONCAT('[UNIQUE_KEY_CONFLICT]','Product with same attribute already exists');
				
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END
	ELSE
	BEGIN
	BEGIN TRY
			INSERT INTO [ProductAttribute]
			(
				ProductId, AttributeId, AttributeValue
			)
			VALUES
			(
				@ProductId, @AttributeId, @AttributeValue
			)
			SET @ProdAttrId = SCOPE_IDENTITY()
	END TRY
	BEGIN CATCH
	

		SELECT 
					@ErrorMessage = 'Error - ' + ERROR_PROCEDURE() + ': ' + ERROR_MESSAGE() + ', Line: ' + CONVERT(VARCHAR(20), ERROR_LINE())
				,	@ErrorSeverity = ERROR_SEVERITY() 
				,	@ErrorState = ERROR_STATE()

		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
	END
END