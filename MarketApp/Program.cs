using MarketApp.Context;
using MarketApp.Entities;
using MarketApp.Log;
namespace MarketApp;

internal class Program
{
    static void Main(string[] args)
    {
        MarketDbContext context = new MarketDbContext();
        int choice;
        bool continator = false;
        Console.WriteLine("1. Sign In\n2. Sign Up\n3. Exit");
        choice = int.Parse(Console.ReadLine());
        Logger log = new Logger();
        switch(choice)
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
            Console.WriteLine("\vManage:\n\t1) products \n\t2)categories \n\t3)orders \n\t4)tags \n\t5)suppliers \n\t6) users");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                //
                //
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }


        }

    }
}
