namespace Models
{
    public class ProductsModel
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public int ItemQuantity { get; set; }
        public float ItemPrice { get; set; }
        public string StoreID { get; set; }
        public int LevelMinimum { get; set; }

        public ProductsModel()
        {
            ItemID = "";
            ItemName = "";
            ItemDesc = "";
            ItemQuantity = 0;
            ItemPrice = 0;
            StoreID = "";
            LevelMinimum = 0;
        }

        public override string ToString()
        {
            return $"Product ID: {ItemID}\nProduct Name: {ItemName}\nDescription: {ItemDesc}\nStock: {ItemQuantity}\nStore: {StoreID}\n";
        }
    }
}