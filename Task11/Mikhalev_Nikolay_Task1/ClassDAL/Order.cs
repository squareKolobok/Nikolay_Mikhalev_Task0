namespace Mikhalev_Nikolay_Task1.ClassDAL//todo не очень корректное имя для папки, лучше назвать Models
{
    using System;

    public class Order
    {
        public int orderID { get; private set; }
        public string CustomerID { get; private set; }
        public int EmployeeID { get; private set; }
        public DateTime OrderDate { get; private set; }
        public DateTime RequiredDate { get; private set; }
        public DateTime ShippedDate { get; private set; }
        public int ShipVia { get; private set; }
        public decimal Freight { get; private set; }
        public string ShipName { get; private set; }
        public string ShipAddress { get; private set; }
        public string ShipCity { get; private set; }
        public string ShipRegion { get; private set; }
        public string ShipPostalCode { get; private set; }
        public string ShipCounty { get; private set; }
        public WorkEnum Status { get; private set; }

        public Order(int orderID, string CustomerID, int EmployeeID, DateTime OrderDate, DateTime RequiredDate, DateTime ShippedDate,
            int ShipVia, decimal Freight, string ShipName, string ShipAddress, string ShipCity, string ShipRegion, string ShipPostalCode, string ShipCounty)
        {
            this.orderID = orderID;
            this.CustomerID = CustomerID;
            this.EmployeeID = EmployeeID;
            this.OrderDate = OrderDate;
            this.RequiredDate = RequiredDate;
            this.ShippedDate = ShippedDate;
            this.ShipVia = ShipVia;
            this.Freight = Freight;
            this.ShipName = ShipName;
            this.ShipAddress = ShipAddress;
            this.ShipCity = ShipCity;
            this.ShipRegion = ShipRegion;
            this.ShipPostalCode = ShipPostalCode;
            this.ShipCounty = ShipCounty;

            if (ShippedDate == DateTime.MinValue)
                if (OrderDate == DateTime.MinValue)
                    Status = WorkEnum.New;
                else
                    Status = WorkEnum.InTheWork;
            else
                Status = WorkEnum.Made;

        }

        public Order(int orderID, string CustomerID, int EmployeeID, int ShipVia, decimal Freight, 
            string ShipName, string ShipAddress, string ShipCity, string ShipRegion, string ShipPostalCodet, string ShipCounty)
            :this(orderID, CustomerID, EmployeeID, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, ShipVia, Freight, 
                 ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCodet, ShipCounty)
        {
        }

        public Order (int orderID, string CustomerID, int EmployeeID)
        {
            this.orderID = orderID;
            this.CustomerID = CustomerID;
            this.EmployeeID = EmployeeID;
        }

    }
}
