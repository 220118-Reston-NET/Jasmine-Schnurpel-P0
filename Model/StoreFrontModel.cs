namespace Models
{

    public class StoreFrontModel
    {
        public string StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }

        public StoreFrontModel()
        {
            StoreID = "";
            StoreName = "";
            StoreAddress = "";
        }

        public override string ToString()
        {
            return $"Store ID: {StoreID} \nName: {StoreName} \nAddress: {StoreAddress}\n";
        }
    }
}