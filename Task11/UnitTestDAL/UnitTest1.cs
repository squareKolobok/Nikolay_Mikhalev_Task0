namespace UnitTestDAL
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mikhalev_Nikolay_Task1;
    using Mikhalev_Nikolay_Task1.ClassDAL;
    using System.Collections.Generic;

    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void ViewsOrdersTest()
        {
            DAL dal = new DAL();
            List<Order> ord = dal.ViewOrders();
            int LastOrder = ord[ord.Count - 1].orderID;
            Assert.IsTrue(ord.Count >= 700);
        }

        [TestMethod]
        public void ViewsOrderTest()
        {
            DAL dal = new DAL();
            List<Products> prod = dal.ViewOrder(10248);
            int id = prod.ToArray()[0].ProductID;
            Assert.IsTrue(id == 11);
        }

        [TestMethod]
        public void CreateOrderTest()
        {
            DAL dal = new DAL();
            List<Order> ord = dal.ViewOrders();
            int LastOrder = ord[ord.Count - 1].orderID;
            Order o = new Order(1, "vinet", 5);
            dal.CreateOrder(o);
            ord = dal.ViewOrders();
            int ind = LastOrder;
            LastOrder = ord[ord.Count - 1].orderID;
            Assert.IsTrue(LastOrder > ind);
        }

        [TestMethod]
        public void DateToRunOrderTest()
        {
            DAL dal = new DAL();
            List<Order> ord = dal.ViewOrders();
            int LastOrder = ord[ord.Count - 1].orderID;
            DateTime lastDate = ord.ToArray()[ord.Count - 1].OrderDate;
            dal.DateToRunOrder(LastOrder);
            ord = dal.ViewOrders();
            DateTime NewDate = ord.ToArray()[ord.Count - 1].OrderDate;
            Assert.IsTrue(NewDate.Year > lastDate.Year);
        }

        [TestMethod]
        public void DateToMadeOrderTest()
        {
            DAL dal = new DAL();
            List<Order> ord = dal.ViewOrders();
            int LastOrder = ord[ord.Count - 1].orderID;
            DateTime lastDate = ord.ToArray()[ord.Count - 1].ShippedDate;
            dal.DateToMadeOrder(LastOrder);
            ord = dal.ViewOrders();
            DateTime NewDate = ord.ToArray()[ord.Count - 1].ShippedDate;
            Assert.IsTrue(NewDate.Year > lastDate.Year);
        }

        [TestMethod]
        public void ViewCustOrderHistTest()
        {
            DAL dal = new DAL();
            List<OrderHist> OH = dal.ViewCustOrderHist("ernsh");
            Assert.IsTrue(OH.ToArray()[0].ProductName.Equals("Alice Mutton") && OH.ToArray()[0].Total == 121);
        }

        [TestMethod]
        public void ViewCustOrdersDetailTest()
        {
            DAL dal = new DAL();
            List<OrdersDetail> ord = dal.ViewCustOrdersDetail(11076);
            Assert.IsTrue(ord[0].ProductName.Equals("Grandma's Boysenberry Spread"));
        }
    }
}
