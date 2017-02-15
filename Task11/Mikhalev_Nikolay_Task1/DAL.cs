namespace Mikhalev_Nikolay_Task1
{
    using ClassDAL;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class DAL : IDAL
    {

        public DAL()
        {
        }

        private string connectionString = ConfigurationManager.ConnectionStrings["NorthwindConection"].ConnectionString;

        private void AddParameter<T>(IDbCommand command, string namePar, T value, DbType type)
        {
            var Sel = command.CreateParameter();
            Sel.ParameterName = namePar;
            Sel.DbType = type;
            Sel.Value = value;
            command.Parameters.Add(Sel);
        }

        /// <summary>
        /// создать новый заказ
        /// </summary>
        /// <param name="NewOrder">заказ</param>
        public void CreateOrder(Order NewOrder)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "SELECT ShipperID From Shippers";
                var reader = command.ExecuteReader();
                List<int> listShipVia = new List<int>();
                
                while (reader.Read())
                    listShipVia.Add(reader.GetInt32(0));

                reader.Close();
                command.CommandText = "INSERT INTO Orders(CustomerID, EmployeeID, ShipVia, Freight, ShipName, ShipAddress, " +
                    "ShipCity, ShipRegion, ShipPostalCode, ShipCountry) values (" + 
                    "@SelCustomerID, @SelEmployeeID, @SelShipVia, @SelFreight, @SelShipName, @SelShipAddress, " +
                    "@SelShipCity, @SelShipRegion, @SelShipPostalCode, @SelShipCountry)";

                int ShipVia = listShipVia.Contains(NewOrder.ShipVia) ? NewOrder.ShipVia : listShipVia[0];
                AddParameter<String>(command, "@SelCustomerID", NewOrder.CustomerID, DbType.String);
                AddParameter<int>(command, "@SelEmployeeID", NewOrder.EmployeeID, DbType.Int32);
                AddParameter<int>(command, "@SelShipVia", ShipVia, DbType.Int32);
                AddParameter<decimal>(command, "@SelFreight", NewOrder.Freight, DbType.Decimal);
                AddParameter<string>(command, "@SelShipName", NewOrder.ShipName ?? String.Empty, DbType.String);
                AddParameter<string>(command, "@SelShipAddress", NewOrder.ShipAddress ?? String.Empty, DbType.String);
                AddParameter<string>(command, "@SelShipCity", NewOrder.ShipCity ?? String.Empty, DbType.String);
                AddParameter<string>(command, "@SelShipRegion", NewOrder.ShipRegion ?? String.Empty, DbType.String);
                AddParameter<string>(command, "@SelShipPostalCode", NewOrder.ShipPostalCode ?? String.Empty, DbType.String);
                AddParameter<string>(command, "@SelShipCountry", NewOrder.ShipCounty ?? String.Empty, DbType.String);

                int i = command.ExecuteNonQuery();
                connection.Close();
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
                    date.Year + "-" + date.Month + "-" + date.Day + " " +
                    date.Hour + ":" + date.Minute + ":" + date.Second + "." + date.Millisecond +
                    "', 121) WHERE OrderID = @SelectOrderId AND ShippedDate IS NULL AND NOT (OrderDate IS NULL)";
                AddParameter<int>(command, "@SelectOrderId", OrderID, DbType.Int32);
                int i = command.ExecuteNonQuery();
                connection.Close();
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
                    date.Year + "-" + date.Month + "-" + date.Day + " " +
                    date.Hour + ":" + date.Minute + ":" + date.Second + "." + date.Millisecond +
                    "', 121) WHERE OrderID = @SelectOrderId AND OrderDate IS NULL";
                AddParameter<int>(command, "@SelectOrderId", OrderID, DbType.Int32);
                int i = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<OrderHist> ViewCustOrderHist(string CustomerID)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "exec CustOrderHist @SelCustomerID";
                AddParameter<string>(command, "@SelCustomerID", CustomerID, DbType.String);
                IDataReader reader = command.ExecuteReader();
                List<OrderHist> list = new List<OrderHist>();

                while (reader.Read())
                {
                    OrderHist oh = new OrderHist(reader.GetString(0), reader.GetInt32(1));
                    list.Add(oh);
                }

                connection.Close();
                return list;
            }
        }

        public List<OrdersDetail> ViewCustOrdersDetail(int OrderID)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "exec CustOrdersDetail @SelectOrderId";
                AddParameter<int>(command, "@SelectOrderId", OrderID, DbType.Int32);
                IDataReader reader = command.ExecuteReader();
                List<OrdersDetail>list = new List<OrdersDetail>();

                while (reader.Read())
                {

                    string a = reader.GetString(0);
                    decimal b = reader.GetDecimal(1);
                    int c = reader.GetInt16(2);
                    int d = reader.GetInt32(3);
                    decimal e = reader.GetDecimal(4);

                    OrdersDetail od = new OrdersDetail(
                        /*reader.GetString(0),
                        reader.GetDecimal(1),
                        reader.GetInt32(2),
                        reader.GetInt32(3),
                        reader.GetDecimal(4)*/
                        a,b,c,d,e
                        );
                    list.Add(od);
                }

                connection.Close();
                return list;
            }
        }

        /// <summary>
        /// посмотреть информацию о конкретном заказе
        /// </summary>
        /// <param name="OrderID">номер заказа</param>
        /// <returns>информация о заказе</returns>
        public List<Products> ViewOrder(int OrderID)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT p.ProductID, p.ProductName, p.SupplierID, p.CategoryID, p.QuantityPerUnit, p.UnitPrice, p.UnitsInStock, " +
                    "p.UnitsOnOrder, p.ReorderLevel, p.Discontinued FROM " +
                    "Products p FULL JOIN [Order Details] od ON p.ProductID = od.ProductID FULL JOIN Orders o ON o.OrderID = od.OrderID " +
                    "WHERE o.OrderID = @SelectOrderId";
                AddParameter<int>(command, "@SelectOrderId", OrderID, DbType.Int32);
                IDataReader reader = command.ExecuteReader();
                List<Products> list = new List<Products>();

                while (reader.Read())
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

                connection.Close();
                return list;
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
                command.CommandText = "SELECT * FROM Orders;";
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

                connection.Close();
                return list;
            }
        }
    }
}
