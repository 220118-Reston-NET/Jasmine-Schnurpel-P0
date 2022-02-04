namespace Models
{
    public class LineItemsModel
    {
        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public int ProductQuantity { get; set; }

        public LineItemsModel()
        {
            ProductNumber = 0;
            ProductName = "";
            ProductPrice = 0;
            ProductQuantity = 0;
        }

        public override string ToString()
        {
            return $"Item ID: {ProductNumber} \nItem Name: {ProductName} \nPrice: ${ProductPrice} \nQuantity: {ProductQuantity} \n";
        }
    }
}