namespace Models
{
    public class ProductsModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public int ProductQuantity { get; set; }
        public float ProductPrice { get; set; }
        public int StoreID { get; set; }

        public ProductsModel()
        {
            ProductID = 0;
            ProductName = "";
            ProductDesc = "";
            ProductQuantity = 0;
            ProductPrice = 0;
            StoreID = 0;
        }

        public override string ToString()
        {
            return $"Product ID: {ProductID}\nProduct Name: {ProductName}\nDescription: {ProductDesc}\nStock: {ProductQuantity}\nPrice: {ProductPrice}\nStore: {StoreID}\n";
        }
    }
}