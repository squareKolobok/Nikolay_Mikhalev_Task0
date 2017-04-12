namespace DAL
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class WorkOrders : IDAL
    {

        public WorkOrders(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private string connectionString;

        private void AddParameter<T>(IDbCommand command, string namePar, T value, DbType type)
        {
            var Sel = command.CreateParameter();
            Sel.ParameterName = namePar;
            Sel.DbType = type;

            if (value != null)
                Sel.Value = value;
            else
                Sel.Value = DBNull.Value;

            command.Parameters.Add(Sel);
        }

        /// <summary>
        /// создать новый заказ
        /// </summary>
        /// <param name="NewOrder">заказ</param>
        public int CreateOrder(Order NewOrder)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "SELECT ShipperID From Shippers";
                var reader = command.ExecuteReader();
                List<int?> listShipVia = new List<int?>();

                while (reader.Read())
                    listShipVia.Add(reader.GetInt32(0));

                reader.Close();
                command.CommandText = "INSERT INTO Orders(CustomerID, EmployeeID, ShipVia, Freight, ShipName, ShipAddress, " +
                    "ShipCity, ShipRegion, ShipPostalCode, ShipCountry) OUTPUT inserted.OrderID values (" +
                    "@SelCustomerID, @SelEmployeeID, @SelShipVia, @SelFreight, @SelShipName, @SelShipAddress, " +
                    "@SelShipCity, @SelShipRegion, @SelShipPostalCode, @SelShipCountry)";

                int? ShipVia = listShipVia.Contains(NewOrder.ShipVia) ? NewOrder.ShipVia : listShipVia[0];
                AddParameter<String>(command, "@SelCustomerID", NewOrder.CustomerID, DbType.String);
                AddParameter<int?>(command, "@SelEmployeeID", NewOrder.EmployeeID, DbType.Int32);
                AddParameter<int?>(command, "@SelShipVia", ShipVia, DbType.Int32);
                AddParameter<decimal?>(command, "@SelFreight", NewOrder.Freight, DbType.Decimal);
                AddParameter<string>(command, "@SelShipName", NewOrder.ShipName ?? String.Empty, DbType.String);
                AddParameter<string>(command, "@SelShipAddress", NewOrder.ShipAddress ?? String.Empty, DbType.String);
                AddParameter<string>(command, "@SelShipCity", NewOrder.ShipCity ?? String.Empty, DbType.String);
                AddParameter<string>(command, "@SelShipRegion", NewOrder.ShipRegion ?? String.Empty, DbType.String);
                AddParameter<string>(command, "@SelShipPostalCode", NewOrder.ShipPostalCode ?? String.Empty, DbType.String);
                AddParameter<string>(command, "@SelShipCountry", NewOrder.ShipCounty ?? String.Empty, DbType.String);

                int i = (int)command.ExecuteScalar();
                return i;
            }
        }

        /// <summary>
        /// устанавливает текущую дату как дату выполнения заказа
        /// </summary>
        /// <param name="OrderID">заказ у которого нужно изменить значение</param>
        public void DateToMadeOrder(int OrderID)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                DateTime date = DateTime.Now;
                command.CommandText = "UPDATE Orders SET ShippedDate = CONVERT(datetime, '" +
                    date.ToString("s").Replace("T", " ") +
                    "', 121) WHERE OrderID = @SelectOrderId AND ShippedDate IS NULL AND NOT (OrderDate IS NULL)";
                AddParameter<int>(command, "@SelectOrderId", OrderID, DbType.Int32);
                int i = command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// устанавливает текущую дату как дату начала заказа
        /// </summary>
        /// <param name="OrderID">заказ у которого нужно изменить значение</param>
        public void DateToRunOrder(int OrderID)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                DateTime date = DateTime.Now;
                command.CommandText = "UPDATE Orders SET OrderDate = CONVERT(datetime, '" +
                    date.ToString("s").Replace("T", " ") +
                    "', 121) WHERE OrderID = @SelectOrderId AND OrderDate IS NULL";
                AddParameter<int>(command, "@SelectOrderId", OrderID, DbType.Int32);
                int i = command.ExecuteNonQuery();
            }
        }
        
        /// <summary>
        /// посмотреть информацию о конкретном заказе
        /// </summary>
        /// <param name="OrderID">номер заказа</param>
        /// <returns>информация о заказе</returns>
        public Order ViewOrder(int OrderID)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM Orders WHERE OrderID = @OrderId ORDER BY OrderID ASC";
                AddParameter<int>(command, "@OrderId", OrderID, DbType.Int32);
                IDataReader reader = command.ExecuteReader();
                Order ord = new Order();

                while (reader.Read())
                {
                    string CustomerID = reader.IsDBNull(1) ? null : reader.GetString(1);
                    int EmployeeID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                    DateTime OrderDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                    DateTime RequiredDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                    DateTime ShippedDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                    int ShipVia = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                    decimal Freight = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7);
                    string ShipName = reader.IsDBNull(8) ? null : reader.GetString(8);
                    string ShipAddress = reader.IsDBNull(9) ? null : reader.GetString(9);
                    string ShipCity = reader.IsDBNull(10) ? null : reader.GetString(10);
                    string ShipRegion = reader.IsDBNull(11) ? null : reader.GetString(11);
                    string ShipPostalCode = reader.IsDBNull(12) ? null : reader.GetString(12);
                    string ShipCounty = reader.IsDBNull(13) ? null : reader.GetString(13);

                    ord = new Order(
                        reader.GetInt32(0),
                        CustomerID,
                        EmployeeID,
                        OrderDate,
                        RequiredDate,
                        ShippedDate,
                        ShipVia,
                        Freight,
                        ShipName,
                        ShipAddress,
                        ShipCity,
                        ShipRegion,
                        ShipPostalCode,
                        ShipCounty
                        );
                }

                reader.Close();
                command.CommandText = "SELECT p.ProductID, p.ProductName, p.SupplierID, p.CategoryID, p.QuantityPerUnit, p.UnitPrice, p.UnitsInStock, " +
                    "p.UnitsOnOrder, p.ReorderLevel, p.Discontinued FROM " +
                    "Products p FULL JOIN [Order Details] od ON p.ProductID = od.ProductID FULL JOIN Orders o ON o.OrderID = od.OrderID " +
                    "WHERE o.OrderID = @SelectOrderId ORDER BY p.ProductID ASC";
                AddParameter<int>(command, "@SelectOrderId", OrderID, DbType.Int32);
                reader = command.ExecuteReader();
                List<Products> list = new List<Products>();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        int SupplierID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        int CategoryID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        string QuantityPerUnit = reader.IsDBNull(4) ? String.Empty : reader.GetString(4);
                        decimal UnitPrice = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5);
                        int UnitsOnOrder = reader.IsDBNull(7) ? 0 : reader.GetInt16(7);
                        int ReorderLevel = reader.IsDBNull(8) ? 0 : reader.GetInt16(8);
                        int UnitsInStock = reader.IsDBNull(6) ? 0 : reader.GetInt16(6);

                        Products p = new Products(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            SupplierID,
                            CategoryID,
                            QuantityPerUnit,
                            UnitPrice,
                            UnitsInStock,
                            UnitsOnOrder,
                            ReorderLevel,
                            reader.GetBoolean(9)
                            );
                        list.Add(p);
                    }
                }

                ord.Prod = list;
                return ord;
            }
        }

        /// <summary>
        /// посмотреть список заказов
        /// </summary>
        /// <returns>список заказов</returns>
        public List<Order> ViewOrders()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Orders ORDER BY OrderID ASC";
                IDataReader reader = command.ExecuteReader();
                List<Order> list = new List<Order>();

                while (reader.Read())
                {
                    string CustomerID = reader.IsDBNull(1) ? String.Empty : reader.GetString(1);
                    int EmployeeID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                    DateTime OrderDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                    DateTime RequiredDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                    DateTime ShippedDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                    int ShipVia = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                    decimal Freight = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7);
                    string ShipName = reader.IsDBNull(8) ? String.Empty : reader.GetString(8);
                    string ShipAddress = reader.IsDBNull(9) ? String.Empty : reader.GetString(9);
                    string ShipCity = reader.IsDBNull(10) ? String.Empty : reader.GetString(10);
                    string ShipRegion = reader.IsDBNull(11) ? String.Empty : reader.GetString(11);
                    string ShipPostalCode = reader.IsDBNull(12) ? String.Empty : reader.GetString(12);
                    string ShipCounty = reader.IsDBNull(13) ? String.Empty : reader.GetString(13);

                    Order o = new Order(
                        reader.GetInt32(0),
                        CustomerID,
                        EmployeeID,
                        OrderDate,
                        RequiredDate,
                        ShippedDate,
                        ShipVia,
                        Freight,
                        ShipName,
                        ShipAddress,
                        ShipCity,
                        ShipRegion,
                        ShipPostalCode,
                        ShipCounty
                        );
                    list.Add(o);
                }

                return list;
            }
        }

        public void UpdateOrder(Order UpdateOrder)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                StringBuilder addStr = new StringBuilder();
                addStr.Append(UpdateOrder.CustomerID != null ? " CustomerID = @CustomerID, " : String.Empty);
                addStr.Append(UpdateOrder.EmployeeID != null ? " EmployeeID = @EmployeeID, " : String.Empty);
                addStr.Append(UpdateOrder.Freight != null ? " Freight = @Freight, " : String.Empty);
                addStr.Append(UpdateOrder.ShipAddress != null ? " ShipAddress = @ShipAddress, " : String.Empty);
                addStr.Append(UpdateOrder.ShipCity != null ? " ShipCity = @ShipCity, " : String.Empty);
                addStr.Append(UpdateOrder.ShipCounty != null ? " ShipCountry = @ShipCountry, " : String.Empty);
                addStr.Append(UpdateOrder.ShipName != null ? " ShipName = @ShipName, " : String.Empty);
                addStr.Append(UpdateOrder.ShipPostalCode != null ? " ShipPostalCode = @ShipPostalCode, " : String.Empty);
                addStr.Append(UpdateOrder.ShipRegion != null ? " ShipRegion = @ShipRegion, " : String.Empty);
                addStr.Append(UpdateOrder.ShipVia != null ? " ShipVia = @ShipVia, " : String.Empty);

                connection.Open();
                var command = connection.CreateCommand();

                if (addStr.Length > 0)
                {
                    command.CommandText = "UPDATE Orders SET " + addStr.ToString().TrimEnd(',', ' ') + " WHERE OrderID = @OrderId";
                    AddParameter<int?>(command, "@OrderId", UpdateOrder.orderID, DbType.Int32);

                    if (UpdateOrder.CustomerID != null) AddParameter(command, "@CustomerID", UpdateOrder.CustomerID, DbType.String);
                    if (UpdateOrder.EmployeeID != null) AddParameter(command, "@EmployeeID", UpdateOrder.EmployeeID, DbType.Int32);
                    if (UpdateOrder.Freight != null) AddParameter(command, "@Freight", UpdateOrder.Freight, DbType.Decimal);
                    if (UpdateOrder.ShipAddress != null) AddParameter(command, "@ShipAddress", UpdateOrder.ShipAddress ?? String.Empty, DbType.String);
                    if (UpdateOrder.ShipCity != null) AddParameter(command, "@ShipCity", UpdateOrder.ShipCity ?? String.Empty, DbType.String);
                    if (UpdateOrder.ShipCounty != null) AddParameter(command, "@ShipCountry", UpdateOrder.ShipCounty ?? String.Empty, DbType.String);
                    if (UpdateOrder.ShipName != null) AddParameter(command, "@ShipName", UpdateOrder.ShipName ?? String.Empty, DbType.String);
                    if (UpdateOrder.ShipPostalCode != null) AddParameter(command, "@ShipPostalCode", UpdateOrder.ShipPostalCode ?? String.Empty, DbType.String);
                    if (UpdateOrder.ShipRegion != null) AddParameter(command, "@ShipRegion", UpdateOrder.ShipRegion ?? String.Empty, DbType.String);
                    if (UpdateOrder.ShipVia != null) AddParameter(command, "@ShipVia", UpdateOrder.ShipVia, DbType.Int32);

                    int i = command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// получить всех заказчиков
        /// </summary>
        /// <returns></returns>
        public List<string> GetCustomerID()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT CustomerID FROM Customers";
                var reader = command.ExecuteReader();
                List<string> list = new List<string>();

                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }

                return list;
            }
        }

        /// <summary>
        /// получить всех исполнителей
        /// </summary>
        /// <returns></returns>
        public List<int> GetEmployeeID()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT EmployeeID FROM Employees";
                var reader = command.ExecuteReader();
                List<int> list = new List<int>();

                while (reader.Read())
                {
                    list.Add(reader.GetInt32(0));
                }

                return list;
            }
        }
    }
}
