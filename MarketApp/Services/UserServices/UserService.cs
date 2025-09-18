using MarketApp.Context;
using MarketApp.Entities;

namespace MarketApp.Services.UserServices;

public class UserService : IUserService
{
    MarketDbContext _context;
    public void CreateUser(User User)
    {
        _context.Users.Add(User);
        _context.SaveChanges();
    }

    public void DeleteUser(int id)
    {
        var User = _context.Users.Find(id);
        if (User != null)
        {
            User.IsDeleted = true;
            User.DeletedDate = DateTime.Now;
        }
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
        if (User != null)
        {
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
        }
        _context.SaveChanges();
    }

}
