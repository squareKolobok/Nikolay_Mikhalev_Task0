using Mikhalev_Nikolay_Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mikhalev_Nikolay_Task1.ClassDAL;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DAL dal = new DAL();
            List<Order> ord = dal.ViewOrders();
            Console.WriteLine(ord[ord.Count].orderID);
            Console.Read();
        }
    }
}
