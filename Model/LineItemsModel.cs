namespace Models
{
    public class LineItemsModel
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public float ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
        public float OrderPrice { get; set; }
        public string OrderID { get; set; }

        public LineItemsModel()
        {
            ItemID = "";
            ItemName = "";
            ItemPrice = 0;
            ItemQuantity = 0;
            OrderPrice = 0;
            OrderID = "";
        }

        public override string ToString()
        {
            return $"Item ID: {ItemID} \nItem Name: {ItemName} \nOrder ID: {OrderID}";
        }
    }
}