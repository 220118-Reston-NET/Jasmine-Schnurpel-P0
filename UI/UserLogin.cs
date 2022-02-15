using BusinessLogic;
using DataAccessLogic;
using Models;

namespace UI
{
    public class UserLogin : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Login Menu");
        }
        public string UserChoice()
        {
            string? _choice = Console.ReadLine();
            switch (_choice)
            {
                case "":
                    return "Exit";
                case "0":
                    return "Main Menu";
                default:
                    Console.WriteLine("Please make a valid selection! \nPress any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return "UserLogin";
            }
        }
    }
}