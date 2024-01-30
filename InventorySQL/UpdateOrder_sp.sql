CREATE PROCEDURE UpdateOrder
    @OrderId INT,
    @Status NVARCHAR(MAX),
    @UpdatedDate DATETIME,
    @ProductId INT
AS
BEGIN
    UPDATE Orders
    SET Status = @Status, UpdatedDate = @UpdatedDate, ProductId = @ProductId
    WHERE Id = @OrderId;
END;