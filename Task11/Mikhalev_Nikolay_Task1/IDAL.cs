namespace Mikhalev_Nikolay_Task1
{
    using Mikhalev_Nikolay_Task1.Models;
    using System.Collections.Generic;

    public interface IDAL
    {
        /// <summary>
        /// посмотреть список заказов
        /// </summary>
        /// <returns>список заказов</returns>
        List<Order> ViewOrders();

        /// <summary>
        /// посмотреть информацию о конкретном заказе
        /// </summary>
        /// <param name="OrderID">номер заказа</param>
        /// <returns>информация о заказе</returns>
        List<Products> ViewOrder(int OrderID);

        /// <summary>
        /// создать новый заказ
        /// </summary>
        /// <param name="CustomerID">номер заказчика</param>
        /// <param name="EmployeeID">номер сотрудника</param>
        void CreateOrder(Order NewOrder);

        /// <summary>
        /// устанавливает текущую дату как дату начала заказа
        /// </summary>
        /// <param name="OrderID">заказ у которого нужно изменить значение</param>
        void DateToRunOrder(int OrderID);

        /// <summary>
        /// устанавливает текущую дату как дату выполнения заказа
        /// </summary>
        /// <param name="OrderID">заказ у которого нужно изменить значение</param>
        void DateToMadeOrder(int OrderID);

        List<OrderHist> ViewCustOrderHist(string EmployeeID);

        List<OrdersDetail> ViewCustOrdersDetail(int OrderID);
    }
}
