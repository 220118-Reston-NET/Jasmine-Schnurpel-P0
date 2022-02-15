namespace UI
{
    public class OrderHistory : IMenu
    {
        public void Display()
        {
            Console.WriteLine("");
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
                    return "OrderHistory";
            }
        }
    }
}