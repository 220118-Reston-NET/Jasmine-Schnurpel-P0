namespace UI
{
    public class SearchUser : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Welcome to the User Search Menu. Please Select from the Following: ");
            Console.WriteLine("[1] View all Users \n[2] Search User by ID \n[3] Return to Apothocary Menu \n[4] Return to Main Menu \n[5] Exit");
        }
        public string UserChoice()
        {
            string? _choice = Console.ReadLine();
            switch (_choice)
            {
                case "1":
                    return "ListUsers";
                case "2":
                    return "SearchUserByID";
                case "3":
                    return "ApothocaryMenu";
                case "4":
                    return "MainMenu";
                case "5":
                    return "Exit";
                default:
                    return "SearchUser";
            }
        }
    }
}