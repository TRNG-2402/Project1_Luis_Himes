

using BookCatalog.DTOs;
using BookCatalog.Models;

namespace BookCatalog.Services;

public interface IOrderService
{
    Task<List<Order>> GetAllOrdersAsync();

    Task<Order> GetOrderByIdAsync(int id);

    Task<List<Order>> GetAllOrdersByCustomerIdAsync(int id);

    Task<Order> CreateOrderAsync(NewOrderDTO newOrder);
}