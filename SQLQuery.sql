CREATE DATABASE BookStoreDB;

CREATE TABLE Authors(
AuthorID int identity primary key,
Name varchar(30) not null,
Country varchar(30)
)

CREATE TABLE Books(
BookID int identity primary key,
Title varchar(30) not null,
Price decimal not null,
PublishedYear int ,
AuthorId int 
 constraint Fk_Authorid_Author
foreign key (AuthorId) references Authors(AuthorID)
)

select * from  books

CREATE TABLE Customers(
CustomerID int identity primary key,
Name varchar(30) not null,
Email varchar(30) unique
)

CREATE TABLE Orders
(OrderID int identity primary key,
CustomerId int not null,
OrderDate date,
TotalAmount decimal(10,2) ,
constraint FK_CustomerId_Customer
FOREIGN key (CustomerId) references Customers(CustomerID)
)

CREATE TABLE OrderItems (
    OrderItemId INT identity PRIMARY KEY,
    OrderId INT NOT NULL,
    BookID INT NOT NULL,
    Quantity INT NOT NULL,  
    SubTotal DECIMAL(10,2),
    CONSTRAINT FK_OrderId_Orders
        FOREIGN KEY (OrderId) REFERENCES Orders(OrderID),
    CONSTRAINT FK_BookId_Books
        FOREIGN KEY (BookID) REFERENCES Books(BookID)
);


insert into Authors values(1,'Tejashree','India'),
(2,'Ian McEwan','U.K.'),
(3,'Olga Tokarczuk','Poland'),
(4,'Alexander Pushkin','Russia'),
(5,'Haruki Murakami','Japan'),
(6,'Tan Twan Eng','Malaysia')


insert into Books(Title,AuthorId,Price,PublishedYear) values('Atonement',2,599,2001),
('Flights',3,399,2007),
('The Captain’s Daughter',4,559,1836),
('Norwegian Wood',5,299,1987),
('The House of Doors',6,799,2023),
('SQL Mastery',1,999,2024)



insert into Customers values('Nisha','Nisha@gmail.com'),
('Sanika','Sanika@gmail.com'),
('Raju','Raju@gmail.com'),
('Kachrashet','Kachrashet@gmail.com'),
('Shyaam','Shyaam@gmail.com'),
('BabuRao','baburao@gmail.com'),
('Baandya','baandya@gmail.com')

select * from Customers;


INSERT INTO Orders ( CustomerID, OrderDate, TotalAmount)
VALUES 
    ( 3, '2021-03-01', 500),
    ( 2, '2024-03-02', 1800.50),
    ( 3, '2023-03-03', 3200.00),
    ( 4, '2024-03-04', 1500.25),
    ( 5, '2020-03-05', 999.00);

INSERT INTO OrderItems (OrderID, BookID, Quantity, SubTotal)
VALUES 
    (1, 1, 10, 2500.00),
    (1, 2, 5, 3200.00),
    (2, 3, 8, 2800.50),
    (3, 4, 6, 3500.75),
    (4, 5, 7, 4200.00),
    (5, 6, 9, 4900.25)


select * from Books
-- Update the price of a book titled "SQL Mastery" by increasing it by 
--10%

Update Books
set Price=Price + (Price*.1)
where Title='SQL Mastery'


delete from Customers  
where CustomerID in (SELECT c.CustomerID FROM Customers c
    LEFT JOIN Orders o ON c.CustomerID = o.CustomerId
    WHERE o.OrderID IS NULL);


select * from Books where Price>2000



select count(BookID) NumberOfBooks 
from Books;

--3. Find books published between 2015 and 2023. 

select * from Books 
where PublishedYear between  2015 and 2023;


select * from Customers where customerID in 
(SELECT o.CustomerID FROM Customers c
     JOIN Orders o ON c.CustomerID = o.CustomerId
    group by o.CustomerId
	having count(*)>=1)

select * from Books where title like '%SQL%';

select * from books where price=(select Max(Price) from books)

select * from Customers where Name like 'A%'  Or Name like 'J%'

select sum(TotalAmount) as Revenue from Orders;

select a.Name Author_Name ,b.Title Book_title 
from Authors a
join Books b
on a.AuthorID = b.AuthorId

SELECT c.CustomerID CustomerID,c.Email  Email, c.PhoneNumber PhoneNumber, 
c.Name Customer_Name, o.OrderID OrderID, o.OrderDate OrderDate, o.TotalAmount TotalAmount
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID;

select b.Title Title, b.AuthorId AuthorId,b.price price,b.PublishedYear PublishedYear
from Books b left join OrdersItems o 
on b.BookId = o.BookId 
where o.bookId is null

select CustomerID, count(orderId) as total_orders 
from orders  
group by customerID



SELECT    o.OrderID  orderID,   oi.BookID BookId,   b.Title Title,   oi.Quantity Quantity
FROM Orders o
JOIN OrderItems oi ON o.OrderID = oi.OrderID
JOIN Books b ON oi.BookID = b.BookID;



select c.CustomerID, Name, Email, PhoneNumber
from Customers c
left join orders o
on c.CustomerId=o.CustomerId



select a.Name 
from Authors a
left join Books b
on a.AuthorId=b.AuthorId
where b.AuthorId is null;

