CREATE TABLE Products
(
    Id INT PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Description NVARCHAR(MAX),
    Weight INT,
    Height INT,
    Width INT,
    Length INT
);
CREATE TABLE Orders
(
    Id INT PRIMARY KEY,
    StatusId INT FOREIGN KEY REFERENCES Status(StatusId),
    CreatedDate DATETIME NOT NULL,
    UpdatedDate DATETIME,
    ProductId INT FOREIGN KEY REFERENCES Products(Id)
);
CREATE TABLE Status
(
    StatusId INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

INSERT INTO Status (StatusId, Name) VALUES
(1, 'NotStarted'),
(2, 'Loading'),
(3, 'InProgress'),
(4, 'Arrived'),
(5, 'Unloading'),
(6, 'Cancelled'),
(7, 'Done');