--1.1  ������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (������� ShippedDate) ������������ � ������� ���������� � ShipVia >= 2. ������ �������� ���� ������ ���� ������ ��� ����� ������������ ����������, �������� ����������� ������ �Writing International Transact-SQL Statements� � Books Online ������ �Accessing and Changing Relational Data Overview�. ���� ����� ������������ ����� ��� ���� �������. ������ ������ ����������� ������ ������� OrderID, ShippedDate � ShipVia.
SELECT 
	OrderID, 
	ShippedDate, 
	ShipVia
FROM
	Orders
WHERE
	ShippedDate >= '06/05/1998'
	AND
	ShipVia >= 2
	
--1.2 �������� ������, ������� ������� ������ �������������� ������ �� ������� Orders. � ����������� ������� ����������� ��� ������� ShippedDate ������ �������� NULL ������ �Not Shipped� � ������������ ��������� ������� CAS�. ������ ������ ����������� ������ ������� OrderID � ShippedDate. 
SELECT
	OrderID,
	
	CASE
		WHEN ShippedDate IS NULL THEN 'No Shipped'
	END AS ShippedDate
FROM
	Orders
WHERE
	ShippedDate IS NULL

--1.3  ������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (ShippedDate) �� ������� ��� ���� ��� ������� ��� �� ����������. � ������� ������ ������������� ������ ������� OrderID (������������� � Order Number) � ShippedDate (������������� � Shipped Date). � ����������� ������� ����������� ��� ������� ShippedDate ������ �������� NULL ������ �Not Shipped�, ��� ��������� �������� ����������� ���� � ������� �� ���������. 
SELECT
	OrderID AS 'Order Number',
	CASE
		WHEN ShippedDate IS NULL THEN 'No Shipped'
		ELSE CONVERT(char, ShippedDate)
	END AS 'Shipped Date'
FROM
	Orders
WHERE
	ShippedDate IS NULL
	OR
	ShippedDate >= '06/05/1998'
	
--2.1 ������� �� ������� Customers ���� ����������, ����������� � USA � Canada. ������ ������� � ������ ������� ��������� IN. ����������� ������� � ������ ������������ � ��������� ������ � ����������� �������. ����������� ���������� ������� �� ����� ���������� � �� ����� ����������.
SELECT
	CompanyName,
	Country
FROM
	Customers
WHERE
	Country IN ('USA', 'Canada')
ORDER BY
	Country,
	CompanyName

--2.2 ������� �� ������� Customers ���� ����������, �� ����������� � USA � Canada. ������ ������� � ������� ��������� IN. ����������� ������� � ������ ������������ � ��������� ������ � ����������� �������. ����������� ���������� ������� �� ����� ����������. 
SELECT
	CompanyName,
	Country
FROM
	Customers
WHERE
	Country NOT IN ('USA', 'Canada')
ORDER BY
	CompanyName
	
--2.3  ������� �� ������� Customers ��� ������, � ������� ��������� ���������. ������ ������ ���� ��������� ������ ���� ��� � ������ ������������ �� ��������. �� ������������ ����������� GROUP BY. ����������� ������ ���� ������� � ����������� �������
SELECT DISTINCT
	Country
FROM
	Customers
ORDER BY
	Country
	DESC

--3.1  ������� ��� ������ (OrderID) �� ������� Order Details (������ �� ������ �����������), ��� ����������� �������� � ����������� �� 3 �� 10 ������������ � ��� ������� Quantity � ������� Order Details. ������������ �������� BETWEEN. ������ ������ ����������� ������ ������� OrderID. 
SELECT DISTINCT
	OrderID
FROM
	[Order Details]
WHERE 
	Quantity BETWEEN 3 AND 10

--3.2 ������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� ����� �� ��������� b � g. ������������ �������� BETWEEN. ���������, ��� � ���������� ������� �������� Germany. ������ ������ ����������� ������ ������� CustomerID � Country � ������������ �� Country.
SELECT
	CustomerID,
	Country
FROM
	Customers
WHERE 
	SUBSTRING(Country,1,1) BETWEEN 'b' AND 'g'
ORDER BY
	Country

--3.3  ������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� ����� �� ��������� b � g, �� ��������� �������� BETWEEN. � ������� ����� �Execution Plan� ���������� ����� ������ ����������������
SELECT
	CustomerID,
	Country
FROM
	Customers
WHERE 
	SUBSTRING(Country,1,1) >= 'b' 
	AND 
	SUBSTRING(Country,1,1) <= 'g'
ORDER BY
	Country
--��������� 3.2 � 3.3 ���������, ��������� ����� ������� � ����� 3.2-3.3 plan

--4.1 � ������� Products ����� ��� �������� (������� ProductName), ��� ����������� ��������� 'chocolade'. ��������, ��� � ��������� 'chocolade' ����� ���� �������� ���� ����� 'c' � �������� - ����� ��� ��������, ������� ������������� ����� �������. ���������: ���������� ������� ������ ����������� 2 ������. 
SELECT
	ProductName
FROM
	Products
WHERE
	ProductName LIKE '%cho_olade%'

--5.1 ����� ����� ����� ���� ������� �� ������� Order Details � ������ ���������� ����������� ������� � ������ �� ���. ��������� ��������� �� ����� � ��������� � ����� 1 ��� ���� ������ money. ������ (������� Discount) ���������� ������� �� ��������� ��� ������� ������. ��� ����������� �������������� ���� �� ��������� ������� ���� ������� ������ �� ��������� � ������� UnitPrice ����. ����������� ������� ������ ���� ���� ������ � ����� �������� � ��������� ������� 'Totals'. 
SELECT
	ROUND(SUM((UnitPrice * (1 - Discount)) * Quantity),2) AS Totals
FROM
	[Order Details]

--5.2 �� ������� Orders ����� ���������� �������, ������� ��� �� ���� ���������� (�.�. � ������� ShippedDate ��� �������� ���� ��������). ������������ ��� ���� ������� ������ �������� COUNT. �� ������������ ����������� WHERE � GROUP. 
SELECT
	COUNT(*) - COUNT(ShippedDate) AS 'Count orders not shipped'
FROM
	Orders

--5.3  �� ������� Orders ����� ���������� ��������� ����������� (CustomerID), ��������� ������. ������������ ������� COUNT � �� ������������ ����������� WHERE � GROUP. 
SELECT
	COUNT(DISTINCT CustomerID) - (COUNT(*) - COUNT(ShippedDate)) 
	AS 
	'Count customers have shipped'
FROM
	Orders

--6.1 �� ������� Orders ����� ���������� ������� � ������������ �� �����. � ����������� ������� ���� ����������� ��� ������� c ���������� Year � Total. �������� ����������� ������, ������� ��������� ���������� ���� �������. 
SELECT
	YEAR(OrderDate) AS 'Year',
	COUNT(OrderDate) AS 'Total'
FROM
	Orders
GROUP BY YEAR(OrderDate)

SELECT 
	COUNT(*) AS 'Count orders' 
FROM 
	Orders 

--6.2 �� ������� Orders ����� ���������� �������, c�������� ������ ���������. ����� ��� ���������� �������� � ��� ����� ������ � ������� Orders, ��� � ������� EmployeeID ������ �������� ��� ������� ��������. � ����������� ������� ���� ����������� ������� � ������ �������� (������ ������������� ��� ���������� ������������� LastName & FirstName. ��� ������ LastName & FirstName ������ ���� �������� ��������� �������� � ������� ��������� �������. ����� �������� ������ ������ ������������ ����������� �� EmployeeID.) � ��������� ������� �Seller� � ������� c ����������� ������� ����������� � ��������� 'Amount'. ���������� ������� ������ ���� ����������� �� �������� ���������� �������. 
SELECT
	LastName + ' ' + FirstName AS 'Seller',
	COUNT(o.EmployeeID) AS 'Amount'
FROM
	Orders o
	INNER JOIN 
	Employees e
	ON
	o.EmployeeID=e.EmployeeID 
GROUP BY
	LastName + ' ' + FirstName
ORDER BY
	COUNT(o.EmployeeID)
	
----6.3 �� ������� Orders ����� ���������� �������, c�������� ������ ��������� � ��� ������� ����������. ���������� ���������� ��� ������ ��� ������� ��������� � 1998 ����. � ����������� ������� ���� ����������� ������� � ������ �������� (�������� ������� �Seller�), ������� � ������ ���������� (�������� ������� �Customer�) � ������� c ����������� ������� ����������� � ��������� 'Amount'. � ������� ���������� ������������ ����������� �������� ����� T-SQL ��� ������ � ���������� GROUP (���� �� �������� ������� �������� ������ �ALL� � ����������� �������). ����������� ������ ���� ������� �� ID �������� � ����������. ���������� ������� ������ ���� ����������� �� ��������, ���������� � �� �������� ���������� ������.
SELECT
	CASE
		WHEN CompanyName IS NULL THEN 'ALL'
		ELSE CompanyName
	END AS Seller,
	CASE
		WHEN FirstName IS NULL THEN 'ALL'
		ELSE FirstName
	END AS Customer,
	COUNT(OrderID) AS Amount
FROM 
	Orders o
	INNER JOIN
	Customers c 
	ON 
	o.CustomerID = c.CustomerID
	INNER JOIN 
	Employees e
	ON 
	o.EmployeeID = e.EmployeeID
WHERE 
	YEAR(OrderDate) = 1998
GROUP BY 
	CUBE (CompanyName,FirstName)
ORDER BY 
	Amount DESC,
	Seller ASC,
	Customer ASC 

--6.4 ����� ����������� � ���������, ������� ����� � ����� ������. ���� � ������ ����� ������ ���� ��� ��������� ��������� ��� ������ ���� ��� ��������� �����������, �� ���������� � ����� ���������� � ��������� �� ������ �������� � �������������� �����. �� ������������ ����������� JOIN. � ����������� ������� ���������� ������� ��������� ��������� ��� ����������� �������: �Person�, �Type� (����� ���� �������� ������ �Customer� ��� �Seller� � ��������� �� ���� ������), �City�. ������������� ���������� ������� �� ������� �City� � �� �Person�. 
--�� ��� � ����� �������, � �� ����� ��� �����������
SELECT
	CASE
		WHEN NOT c.CustomerID IS NULL THEN c.CompanyName
		WHEN NOT e.EmployeeID IS NULL THEN e.LastName
		ELSE c.CompanyName + ' AND ' + e.LastName
	END AS Person,
	CASE
		WHEN NOT c.CustomerID IS NULL THEN 'Customer'
		WHEN NOT e.EmployeeID IS NULL THEN 'Seller'
		ELSE 'Customer AND Seller'
	END AS 'Type',
	e.City AS City
FROM
	Employees e,
	Customers c
WHERE
	e.City = c.City
ORDER BY
	City,
	Person
	
--6.5 ����� ���� �����������, ������� ����� � ����� ������. � ������� ������������ ���������� ������� Customers c ����� - ��������������. ��������� ������� CustomerID � City. ������ �� ������ ����������� ����������� ������. ��� �������� �������� ������, ������� ����������� ������, ������� ����������� ����� ������ ���� � ������� Customers. ��� �������� ��������� ������������ �������. 
SELECT DISTINCT
	e.CustomerID AS CustomerID,
	e.City AS City
FROM
	Customers e
	INNER JOIN
	Customers c
	ON 
	e.City = c.City
WHERE
	e.City = c.City
	AND
	e.CustomerID <> c.CustomerID
	
--6.6 �� ������� Employees ����� ��� ������� �������� ��� ������������, �.�. ���� �� ������ �������. ��������� ������� � ������� 'User Name' (LastName) � 'Boss'. � �������� ������ ���� ��������� ����� �� ������� LastName. 
SELECT
	c.LastName AS 'User Name',
	e.LastName AS BOSS
FROM
	Employees e
	INNER JOIN
	Employees c
	ON 
	e.EmployeeID = c.ReportsTo

--7.1  ���������� ���������, ������� ����������� ������ 'Western' (������� Region). ���������� ������� ������ ����������� ��� ����: 'LastName' �������� � �������� ������������� ���������� ('TerritoryDescription' �� ������� Territories). ������ ������ ������������ JOIN � ����������� FROM. ��� ����������� ������ ����� ��������� Employees � Territories ���� ������������ ����������� ��������� ��� ���� Northwind. 
SELECT
	e.LastName,
	t.TerritoryDescription
FROM
	Employees e
	INNER JOIN
	EmployeeTerritories et
	ON
	e.EmployeeID = et.EmployeeID
	INNER JOIN
	Territories t
	ON
	t.TerritoryID=et.TerritoryID
	INNER JOIN
	Region r
	ON
	r.RegionID = t.RegionID
WHERE
	r.RegionDescription = 'Western'

--8.1 ��������� � ����������� ������� ����� ���� ���������� �� ������� Customers � ��������� ���������� �� ������� �� ������� Orders. ������� �� ��������, ��� � ��������� ���������� ��� �������, �� ��� ����� ������ ���� �������� � ����������� �������. ����������� ���������� ������� �� ����������� ���������� �������.
SELECT
	c.CustomerID AS Customer,
	COUNT(o.OrderID) AS Orders
FROM
	Customers c
	LEFT JOIN
	Orders o
	ON
	c.CustomerID=o.CustomerID
GROUP BY
	c.CustomerID
ORDER BY
	Orders

--9.1  ��������� ���� ����������� ������� CompanyName � ������� Suppliers, � ������� ��� ���� �� ������ �������� �� ������ (UnitsInStock � ������� Products ����� 0). ������������ ��������� SELECT ��� ����� ������� � �������������� ��������� IN. ����� �� ������������ ������ ��������� IN �������� '=' ? 
--��� �������� ������������ = � ���� ������ �� ����������, �� �� ������, �� �� � ����������� �������
SELECT 
	CompanyName 
FROM 
	Suppliers s
	INNER JOIN 
	Products p
	ON 
	p.SupplierID = s.SupplierID
WHERE 
	p.SupplierID IN(
	SELECT 
		s.SupplierID 
	FROM 
		Suppliers
	WHERE 
		UnitsInStock IN (0)
	)

--10.1 ��������� ���� ���������, ������� ����� ����� 150 �������. ������������ ��������� ��������������� SELECT.
SELECT 
	LastName
FROM 
	Employees
WHERE 
	EmployeeID IN (
	SELECT 
		EmployeeID
	FROM 
		Orders
	GROUP BY 
		EmployeeID
	HAVING 
		COUNT(OrderID) > 150
	)

--11.1 ��������� ���� ���������� (������� Customers), ������� �� ����� �� ������ ������ (��������� �� ������� Orders). ������������ ��������������� SELECT � �������� EXISTS. 
SELECT
	c.CustomerID
FROM
	Customers c
WHERE
	NOT EXISTS(
	SELECT
		o.CustomerID	
	FROM
		Orders o
	WHERE
		o.CustomerID=c.CustomerID
	)

--12.1 ��� ������������ ����������� ��������� Employees ��������� �� ������� Employees ������ ������ ��� ���� ��������, � ������� ���������� ������� Employees (������� LastName ) �� ���� �������. ���������� ������ ������ ���� ������������ �� ����������� 
SELECT DISTINCT
	SUBSTRING(LastName, 1, 1) AS ABC
FROM
	Employees
ORDER BY
	ABC
	
--13.1
exec GreatestOrders 1997

--13.2
exec SpecifiedDelay

--13.4
exec IsBoss 2