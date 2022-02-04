namespace Models
{
    public class CustomerModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int UserLevel { get; set; }
        public string UserAddress { get; set; }
        public string UserEmail { get; set; }

        public CustomerModel()
        {
            UserID = 0;
            UserName = "User";
            UserLevel = 1;
            UserAddress = "None";
            UserEmail = "None";
        }
        public override string ToString()
        {
            return $"ID: {UserID} Name: {UserName} \nLevel: {UserLevel} \nAddress: {UserAddress} \nEmail: {UserEmail} \n";
        }
    }
}

