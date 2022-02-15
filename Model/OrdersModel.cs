namespace Models
{
    public class OrdersModel
    {
        public string OrderID { get; set; }
        public List<LineItemsModel> LineItems { get; set; }
        public float OrderPrice { get; set; }
        public string StoreID { get; set; }
        public string UserID { get; set; }

        public OrdersModel()
        {
            OrderID = "";
            LineItems = new List<LineItemsModel>() { new LineItemsModel() };
            OrderPrice = 0;
            StoreID = "";
            UserID = "";
        }
    }
}