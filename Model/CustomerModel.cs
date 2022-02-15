namespace Models
{
    public class CustomerModel
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public int UserLevel { get; set; }
        public string UserAddress { get; set; }
        public string UserEmail { get; set; }

        public CustomerModel()
        {
            UserID = "";
            UserName = "";
            UserLevel = 0;
            UserAddress = "";
            UserEmail = "";
        }
        public override string ToString()
        {
            return $"ID: {UserID} Name: {UserName} \nAddress: {UserAddress} \nEmail: {UserEmail} \n";
        }
    }
}

