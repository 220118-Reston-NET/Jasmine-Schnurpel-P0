namespace Models
{
    public class OrdersModel
    {
        public int OrderNumber { get; set; }
        public List<LineItemsModel> LineItems { get; set; }
        public float OrderPrice { get; set; }
        public int StoreID { get; set; }
        public int UserID { get; set; }

        public OrdersModel()
        {
            OrderNumber = 0;
            LineItems = new List<LineItemsModel>() { new LineItemsModel() };
            OrderPrice = 0;
            StoreID = 0;
            UserID = 0;
        }
    }
}