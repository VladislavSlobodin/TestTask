using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<User?> GetUser() => _context.Users.OrderByDescending(u => u.Orders.Count).FirstOrDefaultAsync();

    public Task<List<User>> GetUsers() => _context.Users.Where(u => u.Status == Enums.UserStatus.Inactive).ToListAsync();
}
