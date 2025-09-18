using MarketApp.Context;
using MarketApp.Entities;
using MarketApp.Services.OrderService;

namespace MarketApp.Services.OrderServices;

public class OrderService: IOrderService
{
    MarketDbContext _context;
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
}
