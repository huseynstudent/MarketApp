using MarketApp.Entities;

namespace MarketApp.Services.UserServices;

interface IUserService
{
    public void CreateUser(User User);
    public List<User> GetAllUsers();
    public User GetUserById(int id);
    public void UpdateUser(int id);
    public void DeleteUser(int id);
}
