--Find the customer(s) who placed the first order 

SELECT * 
FROM Customers
WHERE CustomerID = (
    SELECT TOP 1 CustomerID
    FROM Orders
    ORDER BY OrderDate DESC
)

--2. Find the customer(s) who placed the most orders. 

SELECT  c.CustomerID, c.Name, c.Email,  COUNT(o.OrderID) AS OrderCount
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.Name, c.Email
having  count(o.OrderID) = (
	select Max(OrderCount) from(
	select Count(CustomerId) OrderCount from orders
	group by CustomerId
	) orders
) 

--3. Find customers who have not placed any orders

select * from Customers
where CustomerID not in (select CustomerID from Orders)


--4. Retrieve all books cheaper than the most expensive book written by
select * from books 
where price < (select Max(Price) from Books)

--List all customers whose total spending is greater than the average spending of all customers

select * from Customers 
where CustomerID in 
	(select CustomerID from Orders
	where TotalAmount >
		(select Avg(Total_Sum) from(
			select sum(TotalAmount) Total_Sum from Orders
			group By CustomerId) AvgAmount
		)
	)

--1. Write a stored procedure that accepts a CustomerID and returns all orders placed by that customer 
Create Procedure GetAllOrderById
 @customerId int 
 As
Begin
Select * from Orders where CustomerId=@customerId
end

exec GetAllOrderById 2


--2. Create a procedure that accepts MinPrice and MaxPrice as parameters and returns all books within that range

Create Proc GetBooks
@minPrice int ,
@maxPrice int
as
Begin
select * from Books where Price between @minPrice and  @maxPrice;
end

exec GetBooks 300,1000

--.Create a view named AvailableBooks that shows only books that are in stock, including BookID, Title, AuthorID, Price, and PublishedYear

create view AvailableBooks
as
select BookID, Title, AuthorID, Price, PublishedYear
from Books


select * from AvailableBooks
