namespace Models
{

    public class StoreFrontModel
    {
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }

        public StoreFrontModel()
        {
            StoreID = 0;
            StoreName = "";
            StoreAddress = "";
        }

        public override string ToString()
        {
            return $"Store ID: {StoreID} \nName: {StoreName} \nAddress: {StoreAddress}\n";
        }
    }
}