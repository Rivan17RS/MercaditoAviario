CREATE PROCEDURE SP_GetAllPurchaseOrders
AS
BEGIN
	SET NOCOUNT ON;

	SELECT p.Id,
			p.Product,
			p.CompanyName,
			p.BuyerPerson,
			p.Quantity,
			p.Email,
			p.Phone,
			p.Price

	FROM PurchaseOrder p
END
