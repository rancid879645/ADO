CREATE PROCEDURE UpdateProduct
    @ProductId INT,
    @Name NVARCHAR(MAX),
    @Description NVARCHAR(MAX),
    @Weight INT,
    @Height INT,
    @Width INT,
    @Length INT
AS
BEGIN
    UPDATE Products
    SET Name = @Name, Description = @Description, Weight = @Weight, Height = @Height, Width = @Width, Length = @Length
    WHERE Id = @ProductId;
END;