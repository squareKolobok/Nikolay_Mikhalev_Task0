namespace UnitTestDAL
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mikhalev_Nikolay_Task1;
    using Mikhalev_Nikolay_Task1.Models;
    using System.Collections.Generic;
    using System.Configuration;

    [TestClass]
    public class UnitTest1
    {

        string connectionString = ConfigurationManager.ConnectionStrings["NorthwindConection"].ConnectionString;

        [TestMethod]
        public void ViewsOrdersTest()
        {
            DAL dal = new DAL(connectionString);
            List<Order> ord = dal.ViewOrders();
            Assert.IsTrue(ord.Count >= 800);
        }

        [TestMethod]
        public void ViewsOrderTest()
        {
            DAL dal = new DAL(connectionString);
            List<Products> prod = dal.ViewOrder(10248);
            var item = from n in prod
                       where n.ProductID == 11
                       select n.ProductName;

            foreach (var x in item)
            {
                Assert.IsTrue(x.ToString().Equals("Queso Cabrales"));
            }
        }

        [TestMethod]
        public void CreateOrderTest()
        {
            DAL dal = new DAL(connectionString);
            List<Order> ord = dal.ViewOrders();
            int LastOrder = ord[ord.Count - 1].orderID;
            Order o = new Order(1, "vinet", 5);
            dal.CreateOrder(o);
            ord = dal.ViewOrders();
            int ind = ord[ord.Count - 1].orderID;
            Assert.IsTrue(LastOrder < ind);
        }

        [TestMethod]
        public void DateToRunOrderTest()
        {
            DAL dal = new DAL(connectionString);
            List<Order> ord = dal.ViewOrders();
            int LastOrder = ord[ord.Count - 1].orderID;
            DateTime lastDate = ord[ord.Count - 1].OrderDate;
            dal.DateToRunOrder(LastOrder);
            ord = dal.ViewOrders();
            DateTime NewDate = ord[ord.Count - 1].OrderDate;
            Assert.IsTrue(NewDate.Year > lastDate.Year);
        }

        [TestMethod]
        public void DateToMadeOrderTest()
        {
            DAL dal = new DAL(connectionString);
            List<Order> ord = dal.ViewOrders();
            int LastOrder = ord[ord.Count - 1].orderID;
            DateTime lastDate = ord[ord.Count - 1].ShippedDate;
            dal.DateToMadeOrder(LastOrder);
            ord = dal.ViewOrders();
            DateTime NewDate = ord[ord.Count - 1].ShippedDate;
            Assert.IsTrue(NewDate.Year > lastDate.Year);
        }

        [TestMethod]
        public void ViewCustOrderHistTest()
        {
            DAL dal = new DAL(connectionString);
            List<OrderHist> OH = dal.ViewCustOrderHist("ernsh");
            var item = from name in OH
                       where name.ProductName.Equals("Alice Mutton")
                       select name.ProductName;
            string f = item.ToString();

            foreach(var x in item)
            {
                Assert.IsTrue(x.Equals("Alice Mutton"));
            }
        }

        [TestMethod]
        public void ViewCustOrdersDetailTest()
        {
            DAL dal = new DAL(connectionString);
            List<OrdersDetail> ord = dal.ViewCustOrdersDetail(11076);
            Assert.IsTrue(ord[0].ProductName.Equals("Grandma's Boysenberry Spread"));
            var item = from name in ord
                       where name.ProductName.Equals("Grandma's Boysenberry Spread")
                       select name.ProductName;
            string f = item.ToString();

            foreach (var x in item)
            {
                Assert.IsTrue(x.Equals("Grandma's Boysenberry Spread"));
            }
        }
    }
}