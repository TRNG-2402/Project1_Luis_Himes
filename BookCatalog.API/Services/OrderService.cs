
using BookCatalog.Data;
using BookCatalog.DTOs;
using BookCatalog.Models;

namespace BookCatalog.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepo _repo;

    public OrderService(IOrderRepo repo)
    {
        _repo = repo;
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        List<Order> result = await _repo.GetAllOrdersAsync();

        if (result is null)
            throw new NullReferenceException("Somehow . . . no orders?");

        return result;
    }

    public async Task<List<Order>> GetAllOrdersByCustomerIdAsync(int id)
    {
        List<Order> result = await _repo.GetAllOrdersByCustomerIdAsync(id);

        if (result is null)
            throw new NullReferenceException($"Somehow . . . no orders by {id}");

        return result;
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        Order? result = await _repo.GetOrderByIdAsync(id);

        if (result is null)
            throw new NullReferenceException("This order doesn't exist");

        return result;
    }

    public async Task<Order> CreateOrderAsync(NewOrderDTO newOrder)
    {
        Order newOrd = new Order();
        OrderBookDTO finOrd = new OrderBookDTO();

        newOrd.CustomerId = newOrder.CustomerId;
        newOrd.DateOrdered = DateTime.Now;
        Order returnedOrd = await _repo.CreateOrderAsync(newOrd);
        finOrd.CustomerId = returnedOrd.CustomerId;
        finOrd.BookId = newOrder.BookId;
        finOrd.DateOrdered = newOrd.DateOrdered;
        finOrd.OrderId = returnedOrd.OrderId;

        await _repo.UpdateOrderAsync(finOrd);

        return returnedOrd;

    }
}