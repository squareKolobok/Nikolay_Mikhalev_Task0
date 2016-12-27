--1.1 - Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (колонка ShippedDate) включительно и которые доставлены с ShipVia >= 2. Формат указания даты должен быть верным при любых региональных настройках, согласно требованиям статьи “Writing International Transact-SQL Statements” в Books Online раздел “Accessing and Changing Relational Data Overview”. Этот метод использовать далее для всех заданий. Запрос должен высвечивать только колонки OrderID, ShippedDate и ShipVia.
SELECT 
	OrderID, 
	ShippedDate, 
	ShipVia
FROM
	Orders
WHERE
	ShippedDate >= '06/05/1998'--неверный запрос. нужно приводить к типу DateTime. CONVERT.
	AND
	ShipVia >= 2
	
--1.2 + Написать запрос, который выводит только недоставленные заказы из таблицы Orders. В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL строку ‘Not Shipped’ – использовать системную функцию CASЕ. Запрос должен высвечивать только колонки OrderID и ShippedDate. 
SELECT
	OrderID,
	
	CASE
		WHEN ShippedDate IS NULL THEN 'No Shipped'
	END AS ShippedDate
FROM
	Orders
WHERE
	ShippedDate IS NULL

--1.3 - Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (ShippedDate) не включая эту дату или которые еще не доставлены. В запросе должны высвечиваться только колонки OrderID (переименовать в Order Number) и ShippedDate (переименовать в Shipped Date). В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL строку ‘Not Shipped’, для остальных значений высвечивать дату в формате по умолчанию. 
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
	ShippedDate >= '06/05/1998'--тоже самое CONVERT
	
--2.1 + Выбрать из таблицы Customers всех заказчиков, проживающих в USA и Canada. Запрос сделать с только помощью оператора IN. Высвечивать колонки с именем пользователя и названием страны в результатах запроса. Упорядочить результаты запроса по имени заказчиков и по месту проживания.
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

--2.2 + Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada. Запрос сделать с помощью оператора IN. Высвечивать колонки с именем пользователя и названием страны в результатах запроса. Упорядочить результаты запроса по имени заказчиков. 
SELECT
	CompanyName,
	Country
FROM
	Customers
WHERE
	Country NOT IN ('USA', 'Canada')
ORDER BY
	CompanyName
	
--2.3 + Выбрать из таблицы Customers все страны, в которых проживают заказчики. Страна должна быть упомянута только один раз и список отсортирован по убыванию. Не использовать предложение GROUP BY. Высвечивать только одну колонку в результатах запроса
SELECT DISTINCT
	Country
FROM
	Customers
ORDER BY
	Country
	DESC

--3.1 + Выбрать все заказы (OrderID) из таблицы Order Details (заказы не должны повторяться), где встречаются продукты с количеством от 3 до 10 включительно – это колонка Quantity в таблице Order Details. Использовать оператор BETWEEN. Запрос должен высвечивать только колонку OrderID. 
SELECT DISTINCT
	OrderID
FROM
	[Order Details]
WHERE 
	Quantity BETWEEN 3 AND 10

--3.2 + Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы из диапазона b и g. Использовать оператор BETWEEN. Проверить, что в результаты запроса попадает Germany. Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.
SELECT
	CustomerID,
	Country
FROM
	Customers
WHERE 
	SUBSTRING(Country,1,1) BETWEEN 'b' AND 'g'
ORDER BY
	Country

--3.3 + Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы из диапазона b и g, не используя оператор BETWEEN. С помощью опции “Execution Plan” определить какой запрос предпочтительнее
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
--стоимость 3.2 и 3.3 одинакова, резкльтат плана показан в файле 3.2-3.3 plan +

--4.1 + В таблице Products найти все продукты (колонка ProductName), где встречается подстрока 'chocolade'. Известно, что в подстроке 'chocolade' может быть изменена одна буква 'c' в середине - найти все продукты, которые удовлетворяют этому условию. Подсказка: результаты запроса должны высвечивать 2 строки. 
SELECT
	ProductName
FROM
	Products
WHERE
	ProductName LIKE '%cho_olade%'

--5.1 + Найти общую сумму всех заказов из таблицы Order Details с учетом количества закупленных товаров и скидок по ним. Результат округлить до сотых и высветить в стиле 1 для типа данных money. Скидка (колонка Discount) составляет процент из стоимости для данного товара. Для определения действительной цены на проданный продукт надо вычесть скидку из указанной в колонке UnitPrice цены. Результатом запроса должна быть одна запись с одной колонкой с названием колонки 'Totals'. 
SELECT
	ROUND(SUM((UnitPrice * (1 - Discount)) * Quantity),2) AS Totals
FROM
	[Order Details]

--5.2 + По таблице Orders найти количество заказов, которые еще не были доставлены (т.е. в колонке ShippedDate нет значения даты доставки). Использовать при этом запросе только оператор COUNT. Не использовать предложения WHERE и GROUP. 
SELECT
	COUNT(*) - COUNT(ShippedDate) AS 'Count orders not shipped'
FROM
	Orders

--5.3 - По таблице Orders найти количество различных покупателей (CustomerID), сделавших заказы. Использовать функцию COUNT и не использовать предложения WHERE и GROUP. 
SELECT
	COUNT(DISTINCT CustomerID) - (COUNT(*) - COUNT(ShippedDate)) --к чему разность? достаточно обычного DISTINCT
	AS 
	'Count customers have shipped'
FROM
	Orders

--6.1 + По таблице Orders найти количество заказов с группировкой по годам. В результатах запроса надо высвечивать две колонки c названиями Year и Total. Написать проверочный запрос, который вычисляет количество всех заказов. 
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

--6.2 - По таблице Orders найти количество заказов, cделанных каждым продавцом. Заказ для указанного продавца – это любая запись в таблице Orders, где в колонке EmployeeID задано значение для данного продавца. В результатах запроса надо высвечивать колонку с именем продавца (Должно высвечиваться имя полученное конкатенацией LastName & FirstName. Эта строка LastName & FirstName должна быть получена отдельным запросом в колонке основного запроса. Также основной запрос должен использовать группировку по EmployeeID.) с названием колонки ‘Seller’ и колонку c количеством заказов высвечивать с названием 'Amount'. Результаты запроса должны быть упорядочены по убыванию количества заказов. 
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
	COUNT(o.EmployeeID) --не выполнено условие задания
	
----6.3 + По таблице Orders найти количество заказов, cделанных каждым продавцом и для каждого покупателя. Необходимо определить это только для заказов сделанных в 1998 году. В результатах запроса надо высвечивать колонку с именем продавца (название колонки ‘Seller’), колонку с именем покупателя (название колонки ‘Customer’) и колонку c количеством заказов высвечивать с названием 'Amount'. В запросе необходимо использовать специальный оператор языка T-SQL для работы с выражением GROUP (Этот же оператор поможет выводить строку “ALL” в результатах запроса). Группировки должны быть сделаны по ID продавца и покупателя. Результаты запроса должны быть упорядочены по продавцу, покупателю и по убыванию количества продаж.
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

--6.4 - Найти покупателей и продавцов, которые живут в одном городе. Если в городе живут только один или несколько продавцов или только один или несколько покупателей, то информация о таких покупателя и продавцах не должна попадать в результирующий набор. Не использовать конструкцию JOIN. В результатах запроса необходимо вывести следующие заголовки для результатов запроса: ‘Person’, ‘Type’ (здесь надо выводить строку ‘Customer’ или ‘Seller’ в завимости от типа записи), ‘City’. Отсортировать результаты запроса по колонке ‘City’ и по ‘Person’. 
--то как я понял задания, я не понял как реалиховать

--очень много лишних строк
-- 1. напиши запрос, который высвечивает города, которые встречаются более одного раза в таблице Customers.
-- 2. напиши запрос, который из одной таблицы (from Customers c1, Customers c2) возвращает пересечение с самой собой.
-- 3. количество записей для каждого города должно соответствовать числу в колонке первого запроса

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
	
--6.5 +- Найти всех покупателей, которые живут в одном городе. В запросе использовать соединение таблицы Customers c собой - самосоединение. Высветить колонки CustomerID и City. Запрос не должен высвечивать дублируемые записи. Для проверки написать запрос, который высвечивает города, которые встречаются более одного раза в таблице Customers. Это позволит проверить правильность запроса. 
SELECT DISTINCT -- чот я не понял, здесь ты разобрался, как пересекать таблицу с самой собой, а в предыдущем нет?
	e.CustomerID AS CustomerID,
	e.City AS City
FROM
	Customers e
	INNER JOIN
	Customers c
	ON 
	e.City = c.City
WHERE
	e.City = c.City--лишнее условие (выше же уже его применил)
	AND
	e.CustomerID <> c.CustomerID
	
--6.6 - По таблице Employees найти для каждого продавца его руководителя, т.е. кому он делает репорты. Высветить колонки с именами 'User Name' (LastName) и 'Boss'. В колонках должны быть высвечены имена из колонки LastName. 
SELECT
	c.LastName AS 'User Name',
	e.LastName AS BOSS
FROM
	Employees e
	INNER JOIN
	Employees c
	ON 
	e.EmployeeID = c.ReportsTo
    -- а у Fuller кто босс? отразить эту информацию в выборке.
    

--7.1 + Определить продавцов, которые обслуживают регион 'Western' (таблица Region). Результаты запроса должны высвечивать два поля: 'LastName' продавца и название обслуживаемой территории ('TerritoryDescription' из таблицы Territories). Запрос должен использовать JOIN в предложении FROM. Для определения связей между таблицами Employees и Territories надо использовать графические диаграммы для базы Northwind. 
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

--8.1 + Высветить в результатах запроса имена всех заказчиков из таблицы Customers и суммарное количество их заказов из таблицы Orders. Принять во внимание, что у некоторых заказчиков нет заказов, но они также должны быть выведены в результатах запроса. Упорядочить результаты запроса по возрастанию количества заказов.
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

--9.1 + Высветить всех поставщиков колонка CompanyName в таблице Suppliers, у которых нет хотя бы одного продукта на складе (UnitsInStock в таблице Products равно 0). Использовать вложенный SELECT для этого запроса с использованием оператора IN. Можно ли использовать вместо оператора IN оператор '=' ? 
--при потпытке использовать = у меня ничего не заработало, то ли нельзя, то ли я неправильно написал
-- "то ли нельзя, то ли я неправильно написал", а разобраться, почему не работает? Со сколькими записями работает IN и со сколькими - "="?
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

--10.1 + Высветить всех продавцов, которые имеют более 150 заказов. Использовать вложенный коррелированный SELECT.
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

--11.1 Высветить всех заказчиков (таблица Customers), которые не имеют ни одного заказа (подзапрос по таблице Orders). Использовать коррелированный SELECT и оператор EXISTS. 
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

--12.1 Для формирования алфавитного указателя Employees высветить из таблицы Employees список только тех букв алфавита, с которых начинаются фамилии Employees (колонка LastName ) из этой таблицы. Алфавитный список должен быть отсортирован по возрастанию 
SELECT DISTINCT
	SUBSTRING(LastName, 1, 1) AS ABC
FROM
	Employees
ORDER BY
	ABC
	
--13.1 - нет проверочного запроса

exec GreatestOrders 1998

--13.2
exec SpecifiedDelay

--13.4 - показать работу запросом, выводящим всех сотрудников (2 колонки - имя и isBoss(yes/no))
exec IsBoss 2