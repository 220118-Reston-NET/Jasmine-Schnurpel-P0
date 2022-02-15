namespace UI
{
    public class CustomerMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Welcome! Please choose from the options below: \n[1] New Customer \n[2] Returning Customer \n[3] Return to Main Menu \n[4] Exit");
        }
        public string UserChoice()
        {
            string? _choice = Console.ReadLine();
            switch (_choice)
            {
                case "1":
                    return "AddUser";
                case "2":
                    return "UserLogin";
                case "3":
                    return "MainMenu";
                case "4":
                    return "Exit";
                default:
                    Console.WriteLine("Please make a valid selection! \nPress any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return "CustomerMenu";
            }
        }
    }
}