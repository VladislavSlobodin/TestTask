using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _context;

    public OrderService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Order?> GetOrder() => _context.Orders.OrderByDescending(o => o.Quantity * o.Price).FirstOrDefaultAsync();
    
    public Task<List<Order>> GetOrders() => _context.Orders.Where(o => o.Quantity > 10).ToListAsync();
}
