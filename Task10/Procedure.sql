--13.1 �������� ���������, ������� ���������� ����� ������� ����� ��� ������� �� ��������� �� ������������ ���. � ����������� �� ����� ���� ��������� ������� ������ ��������, ������ ���� ������ ���� � ����� �������. � ����������� ������� ������ ���� �������� ��������� �������: ������� � ������ � �������� �������� (FirstName � LastName � ������: Nancy Davolio), ����� ������ � ��� ���������. � ������� ���� ��������� Discount ��� ������� �������. ��������� ���������� ���, �� ������� ���� ������� �����, � ���������� ������������ �������. ���������� ������� ������ ���� ����������� �� �������� ����� ������. ��������� ������ ���� ����������� � �������������� ��������� SELECT � ��� ������������� ��������. �������� ������� �������������� GreatestOrders. ���������� ������������������ ������������� ���� ��������. ����� ������ ������������ ������� �������� � ������� Query.sql ���� �������� ��������� �������������� ����������� ������ ��� ������������ ������������ ������ ��������� GreatestOrders. ����������� ������ ������ �������� � ������� ��� ��������� � ������������ ������ �������� ���� ��� ������������� �������� ��� ���� ��� ������� �� ������������ ��������� ��� � ����������� ��������� �������: ��� ��������, ����� ������, ����� ������. ����������� ������ �� ������ ��������� ������, ���������� � ���������, - �� ������ ��������� ������ ��, ��� ������� � ����������� �� ����.
CREATE PROCEDURE GreatestOrders @year INT
AS SELECT
	e.FirstName,
	e.LastName,
	o.OrderID,
	((od.UnitPrice * (1 - od.Discount)) * od.Quantity) AS 'Max Price'
FROM
	Employees e
	INNER JOIN
	Orders o
	ON
	e.EmployeeID = o.EmployeeID
	INNER JOIN
	[Order Details] od
	ON
	od.OrderID = o.OrderID
WHERE
	YEAR(o.OrderDate) = @year
	AND
	((UnitPrice * (1 - Discount)) * Quantity) = (
	SELECT
		MAX((UnitPrice * (1 - Discount)) * Quantity)
	FROM
		Orders o
		INNER JOIN
		[Order Details] od
		ON
		od.OrderID = o.OrderID
	WHERE
		YEAR(o.OrderDate) = @year
	)

--13.2 �������� ���������, ������� ���������� ������ � ������� Orders, �������� ���������� ����� �������� � ���� (������� ����� OrderDate � ShippedDate). � ����������� ������ ���� ���������� ������, ���� ������� ��������� ���������� �������� ��� ��� �������������� ������. �������� �� ��������� ��� ������������� ����� 35 ����. �������� ��������� ShippedOrdersDiff. ��������� ������ ����������� ��������� �������: OrderID, OrderDate, ShippedDate, ShippedDelay (�������� � ���� ����� ShippedDate � OrderDate), SpecifiedDelay (���������� � ��������� ��������). ���������� ������������������ ������������� ���� ���������.
CREATE PROCEDURE SpecifiedDelay @day INT = 35
AS SELECT
	OrderID,
	OrderDate,
	ShippedDate,
	DATEDIFF(d, OrderDate, ShippedDate) AS ShippedDelay
FROM
	Orders
WHERE
	DATEDIFF(d, OrderDate, ShippedDate) > @day
	OR
	ShippedDate IS NULL

--13.3�������� ���������, ������� ����������� ���� ����������� ��������� ��������, ��� ����������������, ��� � ����������� ��� �����������. � �������� �������� ��������� ������� ������������ EmployeeID. ���������� ����������� ����� ����������� � ��������� �� � ������ (������������ �������� PRINT) �������� �������� ����������. ��������, ��� �������� ���� ����� ����������� ����� ������ ���� ��������. �������� ��������� SubordinationInfo. � �������� ��������� ��� ������� ���� ������ ���� ������������ ������, ����������� � Books Online � ��������������� Microsoft ��� ������� ��������� ���� �����. ������������������ ������������� ���������.
--�� ��������
CREATE PROCEDURE SubordinationInfo @EmployeeID INT
AS SELECT
	LastName + ' ' + FirstName AS Name
FROM
	Employees 
IF (ReportsTo = @EmployeeID)
	BEGIN
		PRINT ' ';
		exec SubordinationInfo EmployeeID;
	END

--13.4 �������� �������, ������� ����������, ���� �� � �������� �����������. ���������� ��� ������ BIT. � �������� �������� ��������� ������� ������������ EmployeeID. �������� ������� IsBoss. ������������������ ������������� ������� ��� ���� ��������� �� ������� Employees.
CREATE FUNCTION IsBoss 
(@EmployeeID INT)
RETURNS BIT
AS 
BEGIN
	IF EXISTS(
	SELECT
		EmployeeID
	FROM
		Employees
	WHERE
		ReportsTo = @EmployeeID
	)
		RETURN 1
	RETURN 0
END