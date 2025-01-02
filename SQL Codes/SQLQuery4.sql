CREATE TABLE Users (
    Password NVARCHAR(50) PRIMARY KEY, -- Hashlenmiþ þifre olacak
    Username NVARCHAR(50) UNIQUE NOT NULL, -- Benzersiz kullanýcý adý
    NameSurname NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(15),
    Address NVARCHAR(MAX)
);
CREATE TABLE Restaurants (
    RestaurantName NVARCHAR(100) NOT NULL,
    CuisineType NVARCHAR(50),
    Location NVARCHAR(100) PRIMARY KEY -- Benzersiz adres
);
CREATE TABLE MenuItems (
    ItemName NVARCHAR(100) PRIMARY KEY, -- Benzersiz ürün adý
    Price DECIMAL(10, 2) NOT NULL,
    Description NVARCHAR(MAX),
    RestaurantLocation NVARCHAR(100) NOT NULL,
    FOREIGN KEY (RestaurantLocation) REFERENCES Restaurants(Location)
);
CREATE TABLE Orders (
    Password NVARCHAR(50) NOT NULL, -- Kullanýcý þifresinin hashlenmiþ hali
    TotalPrice DECIMAL(10, 2) NOT NULL,
    Quantity INT NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    ItemPrice DECIMAL(10, 2),
    PRIMARY KEY (Password, OrderDate), -- Kullanýcý þifresi ve sipariþ tarihi benzersiz
    FOREIGN KEY (Password) REFERENCES Users(Password)
);
CREATE TABLE Payment (
PaymentInformation NVARCHAR(MAX),
Password NVARCHAR(50) NOT NULL,
OrderDate DATETIME NOT NULL,
PRIMARY KEY (Password, OrderDate),
FOREIGN KEY (Password, OrderDate) REFERENCES Orders(Password, OrderDate)
);
CREATE TABLE Reviews (
    Password NVARCHAR(50) NOT NULL,
    RestaurantLocation NVARCHAR(100) NOT NULL,
    LikeCount INT DEFAULT 0,
    DislikeCount INT DEFAULT 0,
    PRIMARY KEY (Password, RestaurantLocation),
    FOREIGN KEY (Password) REFERENCES Users(Password),
    FOREIGN KEY (RestaurantLocation) REFERENCES Restaurants(Location)
);