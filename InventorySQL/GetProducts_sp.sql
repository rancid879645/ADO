CREATE PROCEDURE GetProducts
    @ProductId INT = NULL
AS
BEGIN
    IF @ProductId IS NOT NULL
    BEGIN        
        SELECT Id, Name, Description, Weight, Height, Width, Length
        FROM Products
        WHERE Id = @ProductId;
    END
    ELSE
    BEGIN        
        SELECT Id, Name, Description, Weight, Height, Width, Length
        FROM Products;
    END
END;