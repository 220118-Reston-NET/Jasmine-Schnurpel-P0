global using Serilog;
using Microsoft.Extensions.Configuration;
using Models;
using DataAccessLogic;
using BusinessLogic;
using UI;

Log.Logger = new LoggerConfiguration().WriteTo.File("./log/userLog.txt").CreateLogger();

var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("SQLConnection.json")
        .Build();
string _connectionString = config.GetConnectionString("ApothocaryDB");

bool repeat = true;
IMenu _mainMenu = new MainMenu();

while (repeat)
{
    Console.Clear();
    _mainMenu.Display();
    string _input = _mainMenu.UserChoice();

    switch (_input)
    {
        case "MainMenu":
            Log.Information("Displayed Main Menu.");
            _mainMenu = new MainMenu();
            break;

        case "CustomerMenu":
            Log.Information("Displayed Customer Menu");
            _mainMenu = new CustomerMenu();
            break;

        case "AddUser":
            Log.Information("Displayed Add Customer Menu");
            _mainMenu = new AddUser(new UserBL(new UserSQLRepo(_connectionString)));
            break;

        case "UserLogin":
            Log.Information("Displayed Customer Login Menu");
            break;

        case "UserAccount":
            Log.Information("Displayed Account Info");
            break;

        case "ShopPotions":
            Log.Information("Displayed Potion Shop");
            break;

        case "ShopPoisons":
            Log.Information("Displayed Poison Shop");
            break;

        case "OrderHistory":
            Log.Information("Displayed Order History");
            break;

        case "ApothocaryMenu":
            //Add to go to apothocary menu
            Log.Information("Displayed Apothocary Menu");
            break;

        case "SearchUser":
            break;

        case "ListUsers":
            Log.Information("Displayed Customer List Menu");
            break;

        case "SearchUserByID":
            break;

        case "PotionShopInfo":
            Log.Information("Displayed PotionShop Info");
            break;

        case "PoisonShopInfo":
            Log.Information("Displayed PoisonShop Info");
            break;

        case "PotionInventory":
            Log.Information("Displayed Potion Inventory");
            break;

        case "PoisonInventory":
            Log.Information("Displayed Poison Inventory");
            break;

        case "ReplenishPotions":
            Log.Information("Displayed ReplenishPotions Menu");
            break;

        case "ReplenishPoisons":
            Log.Information("Displayed ReplenishPoisons Menu");
            break;

        case "Exit":
            Log.Information("User Exited Application");
            Console.Clear();
            Console.WriteLine("Goodbye!");
            Console.ReadLine();
            Log.CloseAndFlush();
            repeat = false;
            break;

        default:
            Console.WriteLine("Page not found.");
            break;
    }
}