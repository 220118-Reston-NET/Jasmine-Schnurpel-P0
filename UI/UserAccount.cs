namespace UI
{
    public class UserAccount : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Select from the following: \n[1] View Account \n[2] View Order History \n[3] ");
        }
        public string UserChoice()
        {
            string? _choice = Console.ReadLine();
            switch (_choice)
            {
                case "":
                    return "";
                default:
                    Console.WriteLine("Please make a valid selection! \nPress any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return "UserAccount";
            }
        }
    }
}