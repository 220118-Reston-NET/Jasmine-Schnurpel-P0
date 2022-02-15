namespace UI
{
    public class MainMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Welcome to The Alchemist's Apothocary! \nHow can we help you? \n[1] Customer Menu \n[2] Shopkeep Menu \n[3] Exit");
        }
        public string UserChoice()
        {
            string? _choice = Console.ReadLine();
            switch (_choice)
            {
                case "1":
                    return "CustomerMenu";
                case "2":
                    return "ApothocaryMenu";
                case "3":
                    return "Exit";
                default:
                    Console.WriteLine("Please make a valid selection! \nPress any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return "MainMenu";
            }
        }
    }
}