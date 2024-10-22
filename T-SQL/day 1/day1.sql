Create Procedure uspDisplayMessage
as
begin
    print 'welcome to .net react session'
end

create procedure uspProductList
as
begin
select * from production.products
order by product_name
end

uspProductList

exec sp_help 'production.products'

create proc uspProductByCategoryId(@categoryID as int)
as
begin
select * from production.products where category_id = @categoryID
end

uspProductByCategoryId 2

create proc uspProductByRange(@startPrice decimal, @endPrice decimal)
as
begin
select * from production.products where list_price >= @startPrice and list_price <= @endPrice
end

exec uspProductByRange 500.0,900.0

alter proc uspProductsByRangeWithOptionalParam(@startPrice as decimal = 200, @endPrice decimal, @name as varchar(max))
with recompile
as
begin
select * from production.products where list_price >= @startPrice and list_price <= @endPrice and product_name like '%' + @name + '%'
end


exec uspProductsByRangeWithOptionalParam  @endPrice = 3000, @name='Trek'
exec sp_helptext 'uspProductsByRangeWithOptionalParam'

alter proc uspProductCountByModelYear(@ModelYear int,@Productcount int OUT)
as
begin
select @Productcount = COUNT(product_id) from production.products where model_year = @ModelYear
end
declare @Count int
exec uspProductCountByModelYear 2018,@Productcount=@Count out
select @Count as 'Number of products'

create proc uspgetCustomers
as
begin
select * from sales.customers
end

exec uspgetCustomers

create proc uspCustomers
as
begin
exec uspgetCustomers
end

exec uspCustomers

-- You need to create a stored procedure that retrieves a list of all customers who have purchased a specific product.
--consider below tables Customers, Orders,Order_items and Products
--Create a stored procedure,it should return a list of all customers who have purchased the specified product, 
--including customer details like CustomerID, CustomerName, and PurchaseDate.
--The procedure should take a ProductID as an input parameter.

alter proc uspGetAllCustomerWhoPurchasedASpecificProduct(@ProductID int)
as
begin
select sc.customer_id, CONCAT(sc.first_name , ' ' , sc.last_name) as 'Customer Name', so.order_date
from sales.customers sc
join
sales.orders so
on so.customer_id = sc.customer_id
join
sales.order_items soi
on soi.order_id = so.order_id
where soi.product_id = @ProductID
end
select * from sales.order_items
select * from sales.orders
exec uspGetAllCustomerWhoPurchasedASpecificProduct 5

--CREATE TABLE Department with the below columns
  --ID,Name
--populate with test data
 
 
--CREATE TABLE Employee with the below columns
  --ID,Name,Gender,DOB,DeptId
--populate with test data

create table Department(
	DepartmentID int primary key,
	DepartmentName varchar(255) not null
)

create table Employee(
	EmployeeID int primary key,
	EmployeeName varchar(255) not null,
	EmployeeGender varchar(255) not null,
	EmployeeDOB Date not null,
	DepartmentID int foreign key(DepartmentID) references Department(DepartmentID) on delete cascade on update cascade
)

insert into Department values(1,'IT'),
(2,'Sales'),
(3,'Marketing'),
(4,'Accounting')

insert into Employee values(1,'Tejas','Male','2002-05-23',1),
(2,'Varun','Male','2002-06-23',1),
(3,'Vinay','Male','2002-03-01',2),
(4,'Akash','Male','2002-04-05',2),
(5,'Varsha','Female','2002-09-06',3),
(6,'Aishwarya','Female','2002-01-08',3),
(7,'Anushka','Female','2002-08-13',4),
(8,'Abhishek','Male','2002-03-19',4)

select * from Department
select * from Employee



--a) Create a procedure to update the Employee details in the Employee table based on the Employee id.
alter proc uspUpdateEmployeeDetail(@EmployeeID int, @NewEmpId int = NULL, @NewEmpName varchar(max) = NULL, @NewEmpGender varchar(max) = NULL, @NewEmpDOB date = NULL, @NewDeptID int = NULL)
as 
begin
update dbo.Employee
set EmployeeID = Coalesce( @NewEmpId, EmployeeID),
	EmployeeName = Coalesce( @NewEmpName, EmployeeName),
	EmployeeGender = Coalesce( @NewEmpGender, EmployeeGender),
	EmployeeDOB = Coalesce( @NewEmpDOB, EmployeeDOB),
	DepartmentID = Coalesce( @NewDeptID, DepartmentID)
where EmployeeID = @EmployeeID
end

exec uspUpdateEmployeeDetail @EmployeeID = 1, @NewEmpDOB = '2002-04-23'
--b) Create a Procedure to get the employee information bypassing the employee gender and department id from the Employee table
create proc uspGetEmployeeDetails(@EmpGender varchar(max),@DeptID int)
as
begin
	select *
	from dbo.Employee
	where EmployeeGender = @EmpGender and DepartmentID = @DeptID
end

exec uspGetEmployeeDetails 'Female', 4
--c) Create a Procedure to get the Count of Employee based on Gender(input)
alter proc uspGetCountOfEmployeeByGender(@EmpGender varchar(max), @EmpCount int out)
with encryption
as
begin
	select @EmpCount = Count(EmployeeID) 
	from dbo.Employee
	where EmployeeGender = @EmpGender
end

declare @Count int
exec uspGetCountOfEmployeeByGender 'Female',@EmpCount = @Count out
select @Count as 'Total Employee by Gender'

exec sp_helptext 'uspGetCountOfEmployeeByGender'

-- Scalar valued func
create function GetAllEmployees()
returns int
as
begin
return (select count(EmployeeID) from dbo.Employee)
end

print dbo.GetAllEmployees()

-- Table Valued Function
-- inline table valued function --> contains single select statement

create function GetEmployeeByID(@empID int)
returns table
as 
return (Select * from dbo.Employee where EmployeeID = @empID)

select * from GetEmployeeByID(4)

create function GetEmployees()
returns table
as 
return (Select * from dbo.Employee)

select * from GetEmployees()
update GetEmployees() set EmployeeDOB = '2003-05-19' where EmployeeID = 4
-- multi statement table valued func -- cannot update cause it is selecting data from temp table
create function GetEmployeewithTheirDepartments()
returns @TempTable table
(EmployeeID int, EmployeeName varchar(max), DepartmentID int, DepartmentName varchar(max))
as
begin
	insert into @TempTable 
	select e.EmployeeID,e.EmployeeName,e.DepartmentID,d.DepartmentName
	from dbo.Employee e
	join
	dbo.Department d
	on e.DepartmentID = d.DepartmentID
	return 
end

select * from GetEmployeewithTheirDepartments()

--3 ) Create a user Defined function to calculate the TotalPrice based on productid and Quantity Products Table

alter function CalculateTotalPrice(@productID int, @Quantity int)
returns decimal(10,2)
as
begin
	declare @TotalPrice decimal(10,2)
	select @TotalPrice = (list_price * @Quantity)
	from production.products
	where product_id = @productID

	return @TotalPrice
end

Select dbo.CalculateTotalPrice(2,10) as 'Total Price'

-- 4) create a function that returns all orders for a specific customer, including details such as OrderID, OrderDate, and the total amount of each order.
create function GetAllOrdersFromASpecificCustomerID(@customerid int)
returns table
as
return
(
	select so.order_id, so.order_date, sum(soi.quantity * soi.list_price) as 'Total Amount'
	from sales.orders so
	join
	sales.order_items soi
	on so.order_id = soi.order_id
	where so.customer_id = @customerid
	group by so.order_id,so.order_date
)

select * from GetAllOrdersFromASpecificCustomerID(3)

-- create a Multistatement table valued function that calculates the total sales for each product, considering quantity and price.
create function CalculateTotalSalesForEachProduct()
returns @TotalSales table
(
	product_id int,
	product_name varchar(max),
	total_sales decimal(10,2)
 )
as
begin
	insert into @TotalSales
	select p.product_id,p.product_name, SUM(soi.quantity * soi.list_price) as 'Total Sales'
	from sales.order_items soi
	join
	production.products p 
	on soi.product_id = p.product_id
	group by p.product_id, p.product_name
	return
end

select * from CalculateTotalSalesForEachProduct()

-- 6)create a  multi-statement table-valued function that lists all customers along with the total amount they have spent on orders.
create function ListAllCustomersAlongWithTheTotalAmountSpent()
returns @CustomersAlongWithTheTotalAmountSpent table
(
	customer_id int,
	customer_name varchar(max),
	total_amount decimal(10,2)
)
as
begin
	insert into @CustomersAlongWithTheTotalAmountSpent
	select sc.customer_id, CONCAT(sc.first_name, ' ', sc.last_name) as customer_name, Sum(soi.quantity * soi.list_price) as 'Total Amount'
	from sales.customers sc
	join
	sales.orders so
	on so.customer_id = sc.customer_id
	join 
	sales.order_items soi
	on soi.order_id = so.order_id
	group by sc.customer_id, sc.first_name, sc.last_name
	return
end

select * from ListAllCustomersAlongWithTheTotalAmountSpent()