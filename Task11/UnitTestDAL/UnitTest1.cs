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
            int LastOrder = ord[ord.Count - 1].orderID;//todo мы же LINQ учили... используй LINQ и объедини эту и следующую строки (везде ниже)
            Assert.IsTrue(ord.Count >= 700);
        }

        [TestMethod]
        public void ViewsOrderTest()
        {
            DAL dal = new DAL();
            List<Products> prod = dal.ViewOrder(10248);
            int id = prod.ToArray()[0].ProductID;//todo тут LINQ
            Assert.IsTrue(id == 11);//todo тут LINQ
        }

        [TestMethod]
        public void CreateOrderTest()
        {
            DAL dal = new DAL();
            List<Order> ord = dal.ViewOrders();
            int LastOrder = ord[ord.Count - 1].orderID;//todo тут LINQ
            Order o = new Order(1, "vinet", 5);
            dal.CreateOrder(o);
            ord = dal.ViewOrders();
            int ind = LastOrder;
            LastOrder = ord[ord.Count - 1].orderID;//todo тут LINQ
            Assert.IsTrue(LastOrder > ind);//todo тут LINQ
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
            DateTime lastDate = ord.ToArray()[ord.Count - 1].ShippedDate;//todo тут LINQ
            dal.DateToMadeOrder(LastOrder);
            ord = dal.ViewOrders();
            DateTime NewDate = ord.ToArray()[ord.Count - 1].ShippedDate;//todo тут LINQ
            Assert.IsTrue(NewDate.Year > lastDate.Year);
        }

        [TestMethod]
        public void ViewCustOrderHistTest()
        {
            DAL dal = new DAL();
            List<OrderHist> OH = dal.ViewCustOrderHist("ernsh");
            Assert.IsTrue(OH.ToArray()[0].ProductName.Equals("Alice Mutton") && OH.ToArray()[0].Total == 121);//todo тут LINQ
        }

        [TestMethod]
        public void ViewCustOrdersDetailTest()
        {
            DAL dal = new DAL();
            List<OrdersDetail> ord = dal.ViewCustOrdersDetail(11076);
            Assert.IsTrue(ord[0].ProductName.Equals("Grandma's Boysenberry Spread"));//todo тут LINQ
        }
    }
}
