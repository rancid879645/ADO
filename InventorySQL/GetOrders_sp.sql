CREATE PROCEDURE GetOrders
    @Month INT = NULL,
    @Year INT = NULL,
    @StatusId INT = NULL,
    @ProductId INT = NULL,
	@OrderId INT = NUll
AS
BEGIN
    SELECT
        Id, StatusId, CreatedDate, UpdatedDate, ProductId
    FROM
        Orders
    WHERE
		(@OrderId IS NULL OR Id = @OrderId)
        AND (@Month IS NULL OR MONTH(CreatedDate) = @Month)
        AND (@Year IS NULL OR YEAR(CreatedDate) = @Year)
        AND (@StatusId IS NULL OR StatusId = @StatusId)
        AND (@ProductId IS NULL OR ProductId = @ProductId)
END