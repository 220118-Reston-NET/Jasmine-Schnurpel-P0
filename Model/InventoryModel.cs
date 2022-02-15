namespace Models
{
    public class InventoryModel
    {
        public string InventoryID { get; set; }
        public string ItemID { get; set; }
        public string StoreID { get; set; }
        public int ItemQuantity { get; set; }

        public InventoryModel()
        {
            InventoryID = "";
            ItemID = "";
            StoreID = "";
            ItemQuantity = 0;
        }
        public override string ToString()
        {
            return $"Quantity : {ItemQuantity}";
        }
    }
}