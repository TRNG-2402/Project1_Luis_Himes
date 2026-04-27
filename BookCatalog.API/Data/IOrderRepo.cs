
using BookCatalog.DTOs;
using BookCatalog.Models;

namespace BookCatalog.Data;

public interface IOrderRepo
{
    Task<List<Order>> GetAllOrdersAsync();


    Task<Order?> GetOrderByIdAsync(int id);

    Task<Order> CreateOrderAsync(Order orderToAdd);

    Task UpdateOrderAsync(OrderBookDTO bookOrder);
    Task<List<Order>> GetAllOrdersByCustomerIdAsync(int id);


}