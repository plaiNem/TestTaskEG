--для теста условные таблицы из задания

--продукты
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY,
    ProductName NVARCHAR(100) NOT NULL
);
GO
CREATE INDEX IDX_Products_ProductName ON Products(ProductName);
GO

--категории
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY,
    CategoryName NVARCHAR(100) NOT NULL
);
GO
CREATE INDEX IDX_Categories_CategoryName ON Categories(CategoryName);
GO


-- связующая таблица для связи many to many между Categories и Products
CREATE TABLE ProductCategories (
    ProductId INT,
    CategoryId INT,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId),
    PRIMARY KEY (ProductId, CategoryId)
);
GO
CREATE INDEX IDX_ProductCategories_ProductId ON ProductCategories(ProductId);
GO
CREATE INDEX IDX_ProductCategories_CategoryId ON ProductCategories(CategoryId);
Go


--наполнение данными
INSERT INTO Products (ProductName) VALUES ('Product1'), ('Product2'), ('Product3');

INSERT INTO Categories (CategoryName) VALUES ('CategoryA'), ('CategoryB');

INSERT INTO ProductCategories (ProductId, CategoryId) VALUES
(1, 1),
(1, 2),
(2, 1);


--запрос
SELECT p.ProductName, c.CategoryName
FROM Products p
LEFT JOIN ProductCategories pc ON p.ProductID = pc.ProductID
LEFT JOIN Categories c ON pc.CategoryID = c.CategoryID
ORDER BY p.ProductName, c.CategoryName;