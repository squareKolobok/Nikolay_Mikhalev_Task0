namespace Mikhalev_Nikolay_Task1.Content
{
    using System.Web.Mvc;
    using DAL;
    using DAL.Models;
    using App_Start;
    using Models;

    public class OrderController : Controller
    {

        private Order correction(Order NotCorrOrd)
        {
            Order ord = new Order();
            ord.orderID = NotCorrOrd.orderID;
            ord.RequiredDate = NotCorrOrd.RequiredDate;
            ord.OrderDate = NotCorrOrd.OrderDate;
            ord.ShippedDate = NotCorrOrd.ShippedDate;
            if (NotCorrOrd.CustomerID != null) ord.CustomerID = NotCorrOrd.CustomerID;
            if (NotCorrOrd.EmployeeID != null) ord.EmployeeID = NotCorrOrd.EmployeeID;
            if (NotCorrOrd.Freight != null) ord.Freight = NotCorrOrd.Freight;
            if (NotCorrOrd.ShipAddress != null) ord.ShipAddress = NotCorrOrd.ShipAddress.Substring(0, NotCorrOrd.ShipAddress.Length >= 60 ? 60 : NotCorrOrd.ShipAddress.Length);
            if (NotCorrOrd.ShipCity != null) ord.ShipCity = NotCorrOrd.ShipCity.Substring(0, NotCorrOrd.ShipCity.Length >= 15 ? 15 : NotCorrOrd.ShipCity.Length);
            if (NotCorrOrd.ShipCounty != null) ord.ShipCounty = NotCorrOrd.ShipCounty.Substring(0, NotCorrOrd.ShipCounty.Length >= 15 ? 5 : NotCorrOrd.ShipCounty.Length);
            if (NotCorrOrd.ShipName != null) ord.ShipName = NotCorrOrd.ShipName.Substring(0, NotCorrOrd.ShipName.Length >= 40 ? 40 : NotCorrOrd.ShipName.Length);
            if (NotCorrOrd.ShipPostalCode != null) ord.ShipPostalCode = NotCorrOrd.ShipPostalCode.Substring(0, NotCorrOrd.ShipPostalCode.Length >= 10 ? 10 : NotCorrOrd.ShipPostalCode.Length);
            if (NotCorrOrd.ShipRegion != null) ord.ShipRegion = NotCorrOrd.ShipRegion.Substring(0, NotCorrOrd.ShipRegion.Length >= 15 ? 15 : NotCorrOrd.ShipRegion.Length);
            return ord;
        }

        [HttpGet]
        public ActionResult ViewOrder()
        {
            WorkOrders ord = new WorkOrders(StringDAL.connectionString);
            var list = ord.ViewOrders();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateOrder()
        {
            WorkOrders ord = new WorkOrders(StringDAL.connectionString);
            CustEmplID id = new CustEmplID();
            id.CustomerID = ord.GetCustomerID();
            id.EmployeeID = ord.GetEmployeeID();
            return View(id);
        }

        [HttpPost]
        public ActionResult CreateOrder(Order order)
        {
            WorkOrders ord = new WorkOrders(StringDAL.connectionString);
            int OrderID = ord.CreateOrder(correction(order));
            return RedirectToAction("Update", "Order", new { OrderID = OrderID });
        }

        [HttpGet]
        public ActionResult Update(int OrderID)
        {
            WorkOrders ord = new WorkOrders(StringDAL.connectionString);
            CusEmpOrd id = new CusEmpOrd();
            id.CustomerID = ord.GetCustomerID();
            id.EmployeeID = ord.GetEmployeeID();
            id.order = ord.ViewOrder(OrderID);
            return View(id);
        }

        [HttpPost]
        public ActionResult Update(Order order, int OrderID)
        {
            if (order != null)
            {
                order.orderID = OrderID;
                WorkOrders ord = new WorkOrders(StringDAL.connectionString);
                order = correction(order);
                ord.UpdateOrder(order);
            }
            return RedirectToAction("Update", "Order", new { OrderID = OrderID });
        }

        [HttpGet]
        public ActionResult SelectOrder(int OrderID)
        {
            WorkOrders ord = new WorkOrders(StringDAL.connectionString);
            Order order = ord.ViewOrder(OrderID);
            return View(order);
        }

        [HttpPost]
        public ActionResult WorkTime(int OrderID)
        {
            WorkOrders ord = new WorkOrders(StringDAL.connectionString);
            ord.DateToRunOrder(OrderID);
            return RedirectToAction("Update", "Order", new { OrderID = OrderID });
        }

        [HttpPost]
        public ActionResult MadeTime(int OrderID)
        {
            WorkOrders ord = new WorkOrders(StringDAL.connectionString);
            ord.DateToMadeOrder(OrderID);
            return RedirectToAction("Update", "Order", new { OrderID = OrderID });
        }
    }
}