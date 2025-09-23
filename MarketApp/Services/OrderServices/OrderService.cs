using MarketApp.Context;
using MarketApp.Entities;
using MarketApp.Services.OrderService;

namespace MarketApp.Services.OrderServices;

public class OrderService: IOrderService
{
    MarketDbContext _context;
    public OrderService()
    {
        _context = new MarketDbContext();
    }
    public void CreateOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void DeleteOrder(int id)
    {
        var Order = _context.Orders.Find(id);
        if (Order != null)

        {
            Order.IsDeleted = true;
            Order.DeletedDate = DateTime.Now;
        }
        _context.SaveChanges();
    }

    public List<Order> GetAllOrders()
    {
        return _context.Orders.Where(c => !c.IsDeleted).ToList();
    }

    public Order GetOrderById(int id)
    {
        return _context.Orders.Find(id);
    }

    public void UpdateOrder(int id)
    {
        var Order = _context.Orders.Find(id);
        if (Order != null)
        {
            Order.UpdatedDate = DateTime.Now;
            Console.WriteLine("Enter new order number:");
            string newOrderNumber = Console.ReadLine();
            Order.OrderNumber = newOrderNumber;
            _context.Orders.Update(Order);
        }
        _context.SaveChanges();
    }

    public void OrderMenu()
    {
        while (true)
        {
            Console.WriteLine("\nOrder Menu:");
            Console.WriteLine("1. Add Order");
            Console.WriteLine("2. Delete Order");
            Console.WriteLine("3. Update Order");
            Console.WriteLine("4. Get Order By Id");
            Console.WriteLine("5. Get All Orders");
            Console.WriteLine("0. Back");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Order o = new Order();
                    Console.Write("Order Number: ");
                    o.OrderNumber = Console.ReadLine();
                    Console.Write("User Id: ");
                    o.UserId = int.Parse(Console.ReadLine());
                    o.CreatedDate = DateTime.Now;
                    CreateOrder(o);
                    Console.WriteLine("Order added.");
                    break;
                case 2:
                    Console.Write("Enter Order Id to delete: ");
                    DeleteOrder(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Order deleted.");
                    break;
                case 3:
                    Console.Write("Enter Order Id to update: ");
                    UpdateOrder(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Order updated.");
                    break;
                case 4:
                    Console.Write("Enter Order Id: ");
                    var order = GetOrderById(int.Parse(Console.ReadLine()));
                    Console.WriteLine(order != null ? $"Id: {order.Id}, Order Number: {order.OrderNumber}, User Id: {order.UserId}"
                        : "Not found.");
                    break;
                case 5:
                    var all = GetAllOrders();
                    foreach (var item in all)
                        Console.WriteLine($"Id: {item.Id}, Order Number: {item.OrderNumber}, User Id: {item.UserId}");
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
