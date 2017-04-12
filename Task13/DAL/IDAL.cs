namespace DAL
{
    using Models;
    using System.Collections.Generic;

    public interface IDAL
    {
        /// <summary>
        /// посмотреть список заказов
        /// </summary>
        /// <returns>список заказов</returns>
        List<Order> ViewOrders();

        /// <summary>
        /// получить всех заказчиков
        /// </summary>
        /// <returns></returns>
        List<string> GetCustomerID();

        /// <summary>
        /// получить всех исполнителей
        /// </summary>
        /// <returns></returns>
        List<int> GetEmployeeID();

        /// <summary>
        /// посмотреть информацию о конкретном заказе
        /// </summary>
        /// <param name="OrderID">номер заказа</param>
        /// <returns>информация о заказе</returns>
        Order ViewOrder(int OrderID);

        /// <summary>
        /// создать новый заказ
        /// </summary>
        /// <param name="CustomerID">номер заказчика</param>
        /// <param name="EmployeeID">номер сотрудника</param>
        int CreateOrder(Order NewOrder);

        /// <summary>
        /// обновить заказ
        /// </summary>
        /// <param name="UpdateOrder">заказ с новыми данными</param>
        void UpdateOrder(Order UpdateOrder);

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
    }
}
