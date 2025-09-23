namespace MarketApp.Log;

using ExamProject.Security;
using MarketApp.Context;
using MarketApp.Entities;
using MarketApp.Services.UserServices;

public class Logger
{
    MarketDbContext _context;
    UserService _uService;
    Hasher _hasher;

    public Logger(UserService uService, Hasher hasher)
    {
        _uService = uService;
        _hasher = hasher;
        _context = new MarketDbContext();
    }
    public bool SignIn()//accept or not
    {
        Console.WriteLine("Enter your mail: (0 to exit)");
        string email = Console.ReadLine();
        if(email=="0") return false;
        List<User> Users = _uService.GetAllUsers();
        foreach (User u in Users)
        {
            if (u.Email == email)
            {
                Console.WriteLine("Enter your password:");
                string password = Console.ReadLine();
                string passwordHash = _hasher.Hash(password);
                if (u.PasswordHash != passwordHash)
                {
                    Console.WriteLine("Wrong password!");
                    return false;
                }
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
        if (string.IsNullOrWhiteSpace(newUser.Email) || string.IsNullOrWhiteSpace(newUser.PasswordHash))
        {
            Console.WriteLine("Email and password are required.");
            return;
        }
        string passwordHash = _hasher.Hash(password);
        newUser.PasswordHash = passwordHash;
        _uService.CreateUser(newUser);
        _context.SaveChanges();
    }
}
