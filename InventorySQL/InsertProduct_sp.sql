CREATE PROCEDURE InsertProduct
	@Id INT,
    @Name NVARCHAR(MAX),
    @Description NVARCHAR(MAX),
    @Weight INT,
    @Height INT,
    @Width INT,
    @Length INT
AS
BEGIN
    INSERT INTO Products (Id,Name, Description, Weight, Height, Width, Length)
    VALUES (@Id,@Name, @Description, @Weight, @Height, @Width, @Length);
END;