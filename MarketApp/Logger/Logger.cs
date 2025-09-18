namespace MarketApp.Logger;
using MarketApp.Entities;
using MarketApp.Services.UserServices;

public class Logger
{
    UserService _userService;
    public bool SignIn()//accept or not
    {
        Console.WriteLine("Enter your mail: (0 to exit)");
        string email = Console.ReadLine();
        if(email=="0") return false;
        List<User> Users = _userService.GetAllUsers();
        foreach (User u in Users)
        {
            if (u.Email == email)
            {
                //unhash password
                Console.WriteLine($"Are you {u.FirstName} {u.LastName}? (1 - true ,0 - false)");
                var answer = Console.ReadLine();
                if (answer == "1") return true;
            }
        }
        return false;
    }
    public void SignUp()
    {
        User newUser = new User();
        Console.WriteLine("Enter your first name:");
        newUser.FirstName = Console.ReadLine();
        Console.WriteLine("Enter your last name:");
        newUser.LastName = Console.ReadLine();
        Console.WriteLine("Enter your email:");
        newUser.Email = Console.ReadLine();
        Console.WriteLine("Enter your password:");
        string password = Console.ReadLine();
        //hash password
        newUser.PasswordHash = password;
        _userService.CreateUser(newUser);
    }
}
