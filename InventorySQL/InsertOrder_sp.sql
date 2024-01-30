CREATE PROCEDURE InsertOrder
	@Id INT,
    @StatusId INT,
    @CreatedDate DATETIME,
    @UpdatedDate DATETIME,
    @ProductId INT
AS
BEGIN
    INSERT INTO Orders (Id, StatusId, CreatedDate, UpdatedDate, ProductId)
    VALUES (@Id, @StatusId, @CreatedDate, @UpdatedDate, @ProductId);
END;