using ExamProject.Security;
using MarketApp.Context;
using MarketApp.Entities;

namespace MarketApp.Services.UserServices;

public class UserService : IUserService
{
    MarketDbContext _context;
    public UserService()
    {
        _context = new MarketDbContext();
    }
    public void CreateUser(User User)
    {
        _context.Users.Add(User);
        _context.SaveChanges();
    }

    public void DeleteUser(int id)
    {

        var user = _context.Users.Find(id);
        if (user == null)
        {
            Console.WriteLine("User wasnt found");
            return;
        }
        user.IsDeleted = true;
        user.DeletedDate = DateTime.Now;
        Console.WriteLine("User was deleted");
        _context.SaveChanges();
    }

    public List<User> GetAllUsers()
    {
        return _context.Users.Where(c => !c.IsDeleted).ToList();
    }

    public User GetUserById(int id)
    {
        return _context.Users.Find(id);
    }

    public void UpdateUser(int id)
    {
        var User = _context.Users.Find(id);
        if (User == null)
        {
            Console.WriteLine("User wasnt found");
            return;
        }
        User.UpdatedDate = DateTime.Now;
        Console.WriteLine("Enter new first name:");
        string newName = Console.ReadLine();
        User.FirstName = newName;
        Console.WriteLine("Enter new last name:");
        string newLastName = Console.ReadLine();
        User.LastName = newLastName;
        Console.WriteLine("Enter new email:");
        string newEmail = Console.ReadLine();
        User.Email = newEmail;
        _context.Users.Update(User);
                    Console.WriteLine("User updated.");

        _context.SaveChanges();
    }

    public void UserMenu()
    {
        while (true)
        {
            Console.WriteLine("\nUser Menu:");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Update User");
            Console.WriteLine("4. Get User By Id");
            Console.WriteLine("5. Get All Users");
            Console.WriteLine("0. Back");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    User u = new User();
                    Console.Write("First Name: ");
                    u.FirstName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    u.LastName = Console.ReadLine();
                    Console.Write("Email: ");
                    u.Email = Console.ReadLine();
                    Console.Write("Password (will be stored as hash): ");
                    string password = Console.ReadLine();
                    Hasher hasher = new Hasher();
                    u.PasswordHash = hasher.Hash(password);
                    u.CreatedDate = DateTime.Now;
                    CreateUser(u);
                    Console.WriteLine("User added.");
                    break;
                case 2:
                    Console.Write("Enter User Id to delete: ");
                    DeleteUser(int.Parse(Console.ReadLine()));

                    break;
                case 3:
                    Console.Write("Enter User Id to update: ");
                    UpdateUser(int.Parse(Console.ReadLine()));
                    break;
                case 4:
                    Console.Write("Enter User Id: ");
                    var user = GetUserById(int.Parse(Console.ReadLine()));
                    Console.WriteLine(user != null
                        ? $"Id: {user.Id}, Name: {user.FirstName} {user.LastName}, Email: {user.Email}"
                        : "Not found.");
                    break;
                case 5:
                    var all = GetAllUsers();
                    foreach (var item in all)
                        Console.WriteLine($"Id: {item.Id}, Name: {item.FirstName} {item.LastName}, Email: {item.Email}");
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
