using ExamProject.Security;
using MarketApp.Context;
using MarketApp.Entities;
using MarketApp.Log;
using MarketApp.Services.CategoryServices;
using MarketApp.Services.OrderServices;
using MarketApp.Services.ProductServices;
using MarketApp.Services.SupplierServices;
using MarketApp.Services.TagServices;
using MarketApp.Services.UserServices;
namespace MarketApp;

internal class Program
{
    static void Main(string[] args)
    {
        MarketDbContext context = new MarketDbContext();
        UserService userService = new UserService();
        Hasher hasher = new Hasher();

        int choice;
        bool continator = false;
        Console.WriteLine("1. Sign In\n2. Sign Up\n3. Exit");
        choice = int.Parse(Console.ReadLine());
        Logger log = new Logger(userService, hasher);

        switch (choice)
        {
            case 1:
                bool signInResult = log.SignIn();
                if (signInResult)
                {
                    Console.WriteLine("Sign in successful!");
                    continator = true;
                }
                else
                {
                    Console.WriteLine("Sign in failed!");
                }
                break;
            case 2:
                log.SignUp();
                Console.WriteLine("Sign up successful!");
                continator = true;
                break;
            case 3:
                Console.WriteLine("Exiting the application.");
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
        if (continator)
        {
            Console.WriteLine("Welcome to the Market Application!");
            while (true)
            {
                Console.WriteLine("\v\vManage:\n\t1) products \n\t2)categories \n\t3)orders \n\t4)tags \n\t5)suppliers \n\t6) users\n0 to exit\n\n");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case (1):
                        ProductService pService = new();
                        pService.ProductMenu();
                        break;
                    case (2):
                        CategoryService cService = new();
                        cService.CategoryMenu();
                        break;
                    case (3):
                        OrderService oService = new();
                        oService.OrderMenu();
                        break;
                    case (4):
                        TagService tService = new();
                        tService.TagMenu();
                        break;
                    case (5):
                        SupplierService sService = new();
                        sService.SupplierMenu();
                        break;
                    case (6):
                        UserService uService = new();
                        uService.UserMenu();
                        break;
                    case (0):
                        Console.WriteLine("Exiting the application.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
