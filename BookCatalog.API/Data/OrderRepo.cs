
using BookCatalog.DTOs;
using BookCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Data;

public class OrderRepo : IOrderRepo
{
    private readonly AppDbContext _context;

    public OrderRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        List<Order> result = await _context.Orders.ToListAsync();
        return result;
    }

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await _context.Orders.FindAsync(id);
    }
    public async Task<List<Order>> GetAllOrdersByCustomerIdAsync(int id)
    {
        List<Order> result = await _context.Orders.Where(p => p.CustomerId == id).ToListAsync();
        return result;
    }

    public async Task<Order> CreateOrderAsync(Order orderToAdd)
    {
        _context.Orders.Add(orderToAdd);
        await _context.SaveChangesAsync();

        return orderToAdd;
    }

    public async Task UpdateOrderAsync(OrderBookDTO bookOrder)
    {
        Book? book = await _context.Books
            .Include(p => p.Orders)
            .FirstOrDefaultAsync(p => p.BookId == bookOrder.BookId);
        if (book is null)
            throw new KeyNotFoundException($"Book {bookOrder.BookId} not found.");

        Order? order = await _context.Orders.FindAsync(bookOrder.OrderId);

        if (order is null)
            throw new KeyNotFoundException($"Order {bookOrder.OrderId} not found.");
        if (book.Orders.Any(t => t.OrderId == bookOrder.OrderId))
            throw new Exception("This order already contains this book");

        book.Orders.Add(order);

        await _context.SaveChangesAsync();


    }
}