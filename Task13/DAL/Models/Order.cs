namespace DAL.Models
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int? orderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCounty { get; set; }
        public List<Products> Prod { get; set; }
        public WorkEnum Status { get; set; }

        public Order()
        {
            Status = WorkEnum.New;
        }

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
            : this(orderID, CustomerID, EmployeeID, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, ShipVia, Freight,
                 ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCodet, ShipCounty)
        {
        }

        public Order(int orderID, string CustomerID, int EmployeeID)
        {
            this.orderID = orderID;
            this.CustomerID = CustomerID;
            this.EmployeeID = EmployeeID;
            Status = WorkEnum.New;
        }

    }
}
