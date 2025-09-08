using MarketApp.Entities;

namespace MarketApp.Services.OrderService;

internal interface IOrderService
{
    public void CreateOrder(Order Order);
    public List<Order> GetAllOrders();
    public Order GetOrderById(int id);
    public void UpdateOrder(int id);
    public void DeleteOrder(int id);
}
