namespace DAL.Models
{
    public class Products
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public int SupplierID { get; private set; }
        public int CategoryID { get; private set; }
        public string QuantityPerUnit { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int UnitsInStock { get; private set; }
        public int UnitsOnOrder { get; private set; }
        public int ReorderLevel { get; private set; }
        public bool Discontinued { get; private set; }

        public Products(int ProductID, string ProductName, int SupplierID, int CategoryID, string QuantityPerUnit, decimal UnitPrice, int UnitsInStock,
            int UnitsOnOrder, int ReorderLevel, bool Discontinued)
        {
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.SupplierID = SupplierID;
            this.CategoryID = CategoryID;
            this.QuantityPerUnit = QuantityPerUnit;
            this.UnitPrice = UnitPrice;
            this.UnitsInStock = UnitsInStock;
            this.UnitsOnOrder = UnitsOnOrder;
            this.ReorderLevel = ReorderLevel;
            this.Discontinued = Discontinued;
        }

        public Products(int ProductID, string ProductName)
        {
            this.ProductID = ProductID;
            this.ProductName = ProductName;
        }
    }
}
