using System.Globalization;
using System.Text.RegularExpressions;
using BusinessLogic;
using DataAccessLogic;
using Models;

namespace UI
{
    public class AddUser : IMenu
    {
        private static CustomerModel _newUser = new CustomerModel();
        private IUserBL _UserBL;
        public AddUser(IUserBL p_User)
        {
            _UserBL = p_User;
        }
        public void Display()
        {
            Console.WriteLine("Welcome, New Customer! Please Fill out all the fields below.");
            Console.WriteLine("");
            Console.WriteLine("[1] UserID: " + _newUser.UserID);
            Console.WriteLine("[2] Name: " + _newUser.UserName);
            Console.WriteLine("[3] Level: " + _newUser.UserLevel);
            Console.WriteLine("[4] Address: " + _newUser.UserAddress);
            Console.WriteLine("[5] E-Mail: " + _newUser.UserEmail);
            Console.WriteLine("");
            Console.WriteLine("[6] Confirm.");
            Console.WriteLine("[7] Login with Existing Account");
            Console.WriteLine("[8] Main Menu");
            Console.WriteLine("[9] Exit");
        }
        public string UserChoice()
        {
            string? _choice = Console.ReadLine();
            switch (_choice)
            {
                case "1":
                    Console.WriteLine("Enter Desired UserID: ");
                    string? _userIDInput = Console.ReadLine();
                    _newUser.UserID = _userIDInput;
                    return "AddUser";

                case "2":
                    Console.WriteLine("Enter Your Name: ");
                    string? _userNameInput = Console.ReadLine();
                    _newUser.UserName = _userNameInput;
                    return "AddUser";

                case "3":
                    Console.WriteLine("Enter Your Level: ");
                    string? _userLevelInput = Console.ReadLine();
                    int _userLevel = Convert.ToInt32(_userLevelInput);
                    _newUser.UserLevel = _userLevel;
                    return "AddUser";

                case "4":
                    Console.WriteLine("Enter Your Address: ");
                    string? _userAddressInput = Console.ReadLine();
                    _newUser.UserAddress = _userAddressInput;
                    return "AddUser";

                case "5":
                    Console.WriteLine("Enter Your Email: ");
                    string? _userEmailInput = Console.ReadLine();
                    _newUser.UserEmail = _userEmailInput;
                    return "AddUser";

                case "6":
                    if (_newUser.UserID == "" || _newUser.UserName == "" || _newUser.UserLevel < 1 || _newUser.UserAddress == "" || _newUser.UserEmail == "")
                    {
                        Console.WriteLine("You need to fill every information above before saving!");
                        System.Threading.Thread.Sleep(2000);
                        return "AddUser";
                    }
                    else
                    {
                        try
                        {
                            Log.Information("Added " + _newUser.UserID + " to Database");
                            _UserBL.AddUser(_newUser);
                            Console.WriteLine(_newUser.UserID + " has been Created!");
                            _newUser = new CustomerModel();
                            Console.WriteLine("Press Any Key to Return to Main Menu.");
                            System.Threading.Thread.Sleep(2000);
                            Console.ReadLine();
                            return "MainMenu";
                        }
                        catch (System.Exception exc)
                        {
                            Log.Warning("Failed to add New User to Database");
                            Console.WriteLine(exc.Message);
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();
                            return "AddUser";
                        }
                    }

                case "7":
                    return "UserLogin";

                case "8":
                    return "MainMenu";

                case "9":
                    return "Exit";

                default:
                    Console.WriteLine("Please make a valid selection! \nPress any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return "AddUser";
            }

        }

    }
}