namespace UI
{
    public class ApothocaryMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Welcome to the Apothocary Menu. \nWhat would you like to do?\n[1] View Potion Shop \n[2] View Poison Shop \n[3] View Customers \n[4]Return to Main Menu \n[5] Exit");
        }
        public string UserChoice()
        {
            string? _choice = Console.ReadLine();
            switch (_choice)
            {
                case "1":
                    return "PotionShop";
                case "2":
                    return "PoisonShop";
                case "3":
                    return "SearchUser";
                case "4":
                    return "Main Menu";
                case "5":
                    return "Exit";
                default:
                    Console.WriteLine("Please make a valid selection! \nPress any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return "ApothocaryMenu";
            }

        }
    }
}