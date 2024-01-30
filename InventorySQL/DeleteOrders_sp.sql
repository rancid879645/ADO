CREATE PROCEDURE DeleteOrders
    @Month INT = NULL,
    @Year INT = NULL,
    @StatusId INT = NULL,
    @ProductId INT = NULL,
	@OrderId INT = NULL
AS
BEGIN
    DELETE FROM Orders
    WHERE
        (@Month IS NULL OR MONTH(CreatedDate) = @Month)
        AND (@Year IS NULL OR YEAR(CreatedDate) = @Year)
        AND (@StatusId IS NULL OR StatusId = @StatusId)
        AND (@ProductId IS NULL OR ProductId = @ProductId)
		AND (@OrderId IS NULL OR Id = @OrderId);
END