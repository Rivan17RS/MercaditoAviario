CREATE PROCEDURE SP_CreatePurchaseOrder
	@Product varchar(250),
	@Quantity int,
	@Price decimal(18,2),
	@BuyerPerson varchar(100),
	@CompanyName varchar(100),
	@Email varchar(100),
	@Phone varchar(12)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[PurchaseOrder]
           ([Product]
           ,[Quantity]
           ,[Price]
           ,[BuyerPerson]
           ,[CompanyName]
           ,[Email]
           ,[Phone])
     VALUES
          (@Product,
           @Quantity,
           @Price,
           @BuyerPerson,
           @CompanyName,
           @Email,
           @Phone
		   )

END
