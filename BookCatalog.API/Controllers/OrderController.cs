using Microsoft.AspNetCore.Mvc;
using BookCatalog.DTOs;
using BookCatalog.Models;
using BookCatalog.Services;

namespace BookCatalog.Controllers;


[Route("api/[Controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        return await _orderService.GetAllOrdersAsync();
    }

    [HttpGet("{orderId}")]
    public async Task<ActionResult<Order>> GetOrderById(int orderId)
    {
        return await _orderService.GetOrderByIdAsync(orderId);
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(NewOrderDTO newOrder)
    {
        return await _orderService.CreateOrderAsync(newOrder);
    }

}