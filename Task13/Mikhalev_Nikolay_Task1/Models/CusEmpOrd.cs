namespace Mikhalev_Nikolay_Task1.Models
{
    using DAL.Models;

    public class CusEmpOrd : CustEmplID
    {
        public Order order { get; set; } 
    }
}