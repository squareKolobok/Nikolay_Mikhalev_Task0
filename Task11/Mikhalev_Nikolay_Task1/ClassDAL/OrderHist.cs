namespace Mikhalev_Nikolay_Task1.ClassDAL
{
    public class OrderHist
    {
        public string ProductName { get; private set; }
        public int Total { get; private set; }

        public OrderHist(string ProductName, int Total)
        {
            this.ProductName = ProductName;
            this.Total = Total;
        }
    }
}
